using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Zýplama kuvveti
    private Rigidbody2D rb;
    private Animator animator; // Animator referansý
    private AudioSource audioSource; // Ses referansý

    public AudioClip jumpSound; // Zýplama sesi
    public AudioClip gameOverSound; // Game Over sesi

    private bool isGameOver = false; // Game over kontrolü

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator bileþenini al
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini al
    }

    void Update()
    {
        if (!isGameOver && Input.GetMouseButtonDown(0)) // Mouse sol tuþu ile zýplama
        {
            rb.velocity = Vector2.up * jumpForce;

            // Animasyonu tetikle
            animator.SetTrigger("JumpTrigger");

            // Zýplama sesini oynat
            PlaySound(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
            FindObjectOfType<GameOverManager>().ShowGameOverUI();
        {
            isGameOver = true;

            // Game Over sesini çal
            PlaySound(gameOverSound);

            // Animator'ý durdur (isteðe baðlý)
            if (animator != null)
            {
                animator.enabled = false;
            }

            

            Debug.Log("Game Over");
            // Oyunu tamamen durdurmak yerine kontrolleri kapattýk
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

