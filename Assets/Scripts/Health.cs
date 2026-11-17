using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue = 50;
    Screenshake camerashake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        camerashake = Camera.main.GetComponent<Screenshake>();
        audioManager = Object.FindAnyObjectByType<AudioManager>();
        scoreKeeper = Object.FindAnyObjectByType<ScoreKeeper>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we hit a damage dealer

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            audioManager.PlayDamageSFX();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        if (applyCameraShake)
        {
            camerashake.Play();
        }
    }
    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreValue);
        }
        Destroy(gameObject);
    }
}
