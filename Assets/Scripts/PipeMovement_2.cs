using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f; // Hareket h�z�

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

     
    }
    
}   
