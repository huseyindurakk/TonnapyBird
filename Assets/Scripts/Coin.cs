using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 2f; // Hareket hýzý
    public float rotationSpeed = 100f; // Dönme hýzý
    private AudioSource audioSource;
    public AudioClip coinSound; // Ses dosyasý

    void Start()
    {
        // AudioSource bileþenini al
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject.");
        }
    }

    void Update()
    {
        // Coin'i sola hareket ettir
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Coin'i kendi z ekseni etrafýnda döndür
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlaySound(coinSound);

            // Coin sayýsýný artýr
            CoinManager.instance.AddCoin(1);

            // Log ekleyelim
            Debug.Log("Coin Destroyed. Requesting SpawnNewCoin.");

            // Coin'i yok et, ancak sesin tamamlanmasý için gecikme ekle
            Destroy(gameObject, 0.2f); // 0.2 saniye gecikmeli yok et
        }
    }

    // PlaySound metodunu burada tanýmla
    private void PlaySound(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("PlaySound: AudioClip is NULL.");
            return;
        }

        if (audioSource == null)
        {
            Debug.LogError("PlaySound: AudioSource is NULL.");
            return;
        }

        Debug.Log("PlaySound: AudioClip and AudioSource are valid. Playing sound...");
        audioSource.PlayOneShot(clip);
    }
}