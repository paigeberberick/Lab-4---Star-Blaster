using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    InputAction moveAction;

    Vector3 moveVector;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
    moveVector = moveAction.ReadValue<Vector2>();

        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
