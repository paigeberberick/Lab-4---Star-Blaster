using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float fireRate = 0.2f;

    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioManager audioManager;
    float nextFireTime;

    void Start()
    {
        audioManager = Object.FindAnyObjectByType<AudioManager>();
        isFiring = useAI;
    }

    void Update()
    {
        if (useAI)
        {
            Fire(); // enemies keep firing continuously
            return;
        }

        // Player: one shot per button press
        bool pressed = (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
                    || (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame);

        if (pressed && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().linearVelocityY = projectileSpeed;
        Destroy(projectile, projectileLifetime);

        if (audioManager != null)
        {
            audioManager.PlayShootingSFX();
        }
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
}