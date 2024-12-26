using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f; // Hareket hýzý

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

     
    }
    
}   
