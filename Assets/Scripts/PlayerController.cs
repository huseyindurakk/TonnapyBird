using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // Z�plama kuvveti
    private Rigidbody2D rb;
    private Animator animator; // Animator referans�
    private AudioSource audioSource; // Ses referans�

    public AudioClip jumpSound; // Z�plama sesi
    public AudioClip gameOverSound; // Game Over sesi

    private bool isGameOver = false; // Game over kontrol�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Animator bile�enini al
        audioSource = GetComponent<AudioSource>(); // AudioSource bile�enini al
    }

    void Update()
    {
        if (!isGameOver && Input.GetMouseButtonDown(0)) // Mouse sol tu�u ile z�plama
        {
            rb.velocity = Vector2.up * jumpForce;

            // Animasyonu tetikle
            animator.SetTrigger("JumpTrigger");

            // Z�plama sesini oynat
            PlaySound(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGameOver)
            FindObjectOfType<GameOverManager>().ShowGameOverUI();
        {
            isGameOver = true;

            // Game Over sesini �al
            PlaySound(gameOverSound);

            // Animator'� durdur (iste�e ba�l�)
            if (animator != null)
            {
                animator.enabled = false;
            }

            

            Debug.Log("Game Over");
            // Oyunu tamamen durdurmak yerine kontrolleri kapatt�k
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

