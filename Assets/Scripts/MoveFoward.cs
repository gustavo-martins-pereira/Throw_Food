using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float moveSpeed = 40f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
