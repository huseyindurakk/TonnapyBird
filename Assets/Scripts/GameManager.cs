using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;  // Game Over UI referansý
    public static GameManager instance;
    public bool isGameOver = false;

    // Game Over ekranýný göster
    public void ShowGameOverUI()
    {
        Time.timeScale = 0f; // Oyunu durdur
        gameOverUI.SetActive(true);
    }

    // Ana Menüye dönmek için Game Over'da çaðrýlýr
    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Zamaný sýfýrla
        SceneManager.LoadScene(0); // MainMenu sahnesini yükle
    }

    // Oyunu baþlatmak için (Play butonu)
    public void StartGame()
    {
        SceneManager.LoadScene(1); // GameScene sahnesini yükle
    }

    // Oyunu kapatmak için (Quit butonu)
    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýþ yapýldý.");
        Application.Quit();
    }
    public void GameOver()
    {
        isGameOver = true;

        // Spawner'ý bul ve durdur
        Spawner spawner = FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            spawner.StopSpawning();
        }

        Debug.Log("Game Over! Spawning Stopped.");
    }

}
