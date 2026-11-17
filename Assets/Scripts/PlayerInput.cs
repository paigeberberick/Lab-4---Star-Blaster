using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void OnAttack(InputValue value)
    {
        shooter.isFiring = value.isPressed;
    }
}