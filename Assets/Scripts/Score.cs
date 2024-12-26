using UnityEngine;

public class Score : MonoBehaviour
{
    private AudioSource audioSource; // Ses referans�
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource bile�enini al
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Oyuncu coin'e dokunursa

        {
            // Skoru art�r
            ScoreManager.instance.AddScore(1);

            
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
