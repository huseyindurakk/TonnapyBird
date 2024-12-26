using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Game Over Panel UI referans�

    // Game Over oldu�unda bu metodu �a��r
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        Invoke("StopGame", 1f); // 2 saniye sonra oyunu durdur
    }

    // Men� sahnesine d�n veya oyunu yeniden ba�lat
    public void LoadScene(string Game)
    {
        Time.timeScale = 1f; // Zaman� normale d�nd�r
        SceneManager.LoadScene("Game");
        
    }
    public void LoadScene1(string Menu)
    {
        Time.timeScale = 1f; // Zaman� normale d�nd�r
        SceneManager.LoadScene("Menu");

    }


    // Oyunu durdur
    private void StopGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
    }
}
