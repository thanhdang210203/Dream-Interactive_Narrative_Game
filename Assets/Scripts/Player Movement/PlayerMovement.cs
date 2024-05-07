using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction movementAction;
    public float speed;
    public float rotationSpeed = 5f;

    private void OnEnable()
    {
        movementAction.Enable();
    }

    private void OnDisable()
    {
        movementAction.Disable();
    }

    void Update()
    {
        Vector2 movementInput = movementAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime;

        // Rotate the character to face the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(movement, Space.World);
    }
}