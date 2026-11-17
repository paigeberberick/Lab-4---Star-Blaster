using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    [SerializeField] bool applyCameraShake;
    Screenshake camerashake;
    AudioManager audioManager;
    void Start()
    {
        camerashake = Camera.main.GetComponent<Screenshake>();
        audioManager = FindObjectOfType<AudioManager>();
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
            Destroy(gameObject);
        }
        if (applyCameraShake)
        {
            camerashake.Play();
        }
    }
}
