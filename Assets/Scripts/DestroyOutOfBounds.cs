using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float outOfTopBoundLimit = 25f;
    private float outOfBottomBoundLimit = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > outOfTopBoundLimit || transform.position.z < outOfBottomBoundLimit)
        {
            Destroy(gameObject);
        }
    }
}
