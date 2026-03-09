using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;

    private readonly float moveSpeed = 10f;
    private readonly float xBoundary = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        float moveValue = moveAction.ReadValue<float>();

        if(transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundary)
        {
            transform.position = new Vector3(xBoundary, transform.position.y, transform.position.z);
        }

        transform.Translate(moveSpeed * moveValue * Time.deltaTime * Vector3.right);
    }
}
