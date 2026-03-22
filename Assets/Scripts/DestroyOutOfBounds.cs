using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float outOfTopBoundLimit = 25f;
    private readonly float outOfBottomBoundLimit = -10f;
    private readonly float outOfSideBoundLimit = 40f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(
            // Top Bound
            transform.position.z > outOfTopBoundLimit || transform.position.z < outOfBottomBoundLimit
            ||
            // Side Bound
            transform.position.x < -outOfSideBoundLimit || transform.position.x > outOfSideBoundLimit
        )
        {
            Destroy(gameObject);

            Debug.Log("Game Over!");
        }
    }
}
