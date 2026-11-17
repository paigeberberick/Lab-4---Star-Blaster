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

    void Start()
    {
        // Explicitly start false for the player, true only for AI
        isFiring = useAI;
    }

    void Update()
    {
        if (!useAI)
        {
            isFiring = (Keyboard.current != null && Keyboard.current.spaceKey.isPressed)
                    || (Mouse.current != null && Mouse.current.leftButton.isPressed);
        }
        Fire();
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
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocityY = projectileSpeed;

            Destroy(projectile, projectileLifetime);

            yield return new WaitForSeconds(fireRate);
        }
    }
}