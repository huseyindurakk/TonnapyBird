using UnityEngine;

public class Score : MonoBehaviour
{
    private AudioSource audioSource; // Ses referansý
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini al
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Oyuncu coin'e dokunursa

        {
            // Skoru artýr
            ScoreManager.instance.AddScore(1);

            
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
