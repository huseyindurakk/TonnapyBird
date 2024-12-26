using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;  // Game Over UI referans�
    public static GameManager instance;
    public bool isGameOver = false;

    // Game Over ekran�n� g�ster
    public void ShowGameOverUI()
    {
        Time.timeScale = 0f; // Oyunu durdur
        gameOverUI.SetActive(true);
    }

    // Ana Men�ye d�nmek i�in Game Over'da �a�r�l�r
    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Zaman� s�f�rla
        SceneManager.LoadScene(0); // MainMenu sahnesini y�kle
    }

    // Oyunu ba�latmak i�in (Play butonu)
    public void StartGame()
    {
        SceneManager.LoadScene(1); // GameScene sahnesini y�kle
    }

    // Oyunu kapatmak i�in (Quit butonu)
    public void QuitGame()
    {
        Debug.Log("Oyundan ��k�� yap�ld�.");
        Application.Quit();
    }
    public void GameOver()
    {
        isGameOver = true;

        // Spawner'� bul ve durdur
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            spawner.StopSpawning();
        }

        Debug.Log("Game Over! Spawning Stopped.");
    }

}
