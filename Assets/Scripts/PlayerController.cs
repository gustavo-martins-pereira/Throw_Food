using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction throwAction;

    [SerializeField]
    private GameObject projectilePrefab;

    private readonly float moveSpeed = 30f;
    private readonly float xBoundary = 15f;
    private readonly float zDownBoundary = 0;
    private readonly float zUpBoundary = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        throwAction = InputSystem.actions.FindAction("Throw");
    }

    // Update is called once per frame
    void Update()
    {
        // ----- Movement -----
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        // X boundary
        // Left Bound
        if(transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        // Right Bound
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }

        // Y boundary
        // Down Bound
        if (transform.position.z < zDownBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zDownBoundary);
        }
        // Up Bound
        if (transform.position.z > zUpBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpBoundary);
        }

        transform.Translate(moveSpeed * Time.deltaTime * new Vector3(moveValue.x, transform.position.y, moveValue.y));

        // ----- Throw Action -----
        if (throwAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
