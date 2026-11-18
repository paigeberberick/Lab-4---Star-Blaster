using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0, 1)] float shootingVolume = 0.5f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0, 1)] float damageVolume = 0.5f;

    static AudioManager instance;
    public static AudioManager Instance => instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingSFX()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayDamageSFX()
    {
        if (damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position, damageVolume);
        }
    }
}