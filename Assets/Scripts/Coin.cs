using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 2f; // Hareket h�z�
    public float rotationSpeed = 100f; // D�nme h�z�
    private AudioSource audioSource;
    public AudioClip coinSound; // Ses dosyas�

    void Start()
    {
        // AudioSource bile�enini al
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

        // Coin'i kendi z ekseni etraf�nda d�nd�r
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlaySound(coinSound);

            // Coin say�s�n� art�r
            CoinManager.instance.AddCoin(1);

            // Log ekleyelim
            Debug.Log("Coin Destroyed. Requesting SpawnNewCoin.");

            // Coin'i yok et, ancak sesin tamamlanmas� i�in gecikme ekle
            Destroy(gameObject, 0.2f); // 0.2 saniye gecikmeli yok et
        }
    }

    // PlaySound metodunu burada tan�mla
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