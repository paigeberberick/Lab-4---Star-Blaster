using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float leftBoundPadding = 0.5f;
    [SerializeField] float rightBoundPadding = 0.5f;
    [SerializeField] float topBoundPadding = 0.5f;
    [SerializeField] float bottomBoundPadding = 0.5f;
    InputAction moveAction;

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");

        InitBounds();
    }


    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void MovePlayer()
    {
    moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPosition = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);

        transform.position = newPosition;
    }
}
