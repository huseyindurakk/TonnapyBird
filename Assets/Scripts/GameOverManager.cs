using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Game Over Panel UI referansý

    // Game Over olduðunda bu metodu çaðýr
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        Invoke("StopGame", 1f); // 2 saniye sonra oyunu durdur
    }

    // Menü sahnesine dön veya oyunu yeniden baþlat
    public void LoadScene(string Game)
    {
        Time.timeScale = 1f; // Zamaný normale döndür
        SceneManager.LoadScene("Game");
        
    }
    public void LoadScene1(string Menu)
    {
        Time.timeScale = 1f; // Zamaný normale döndür
        SceneManager.LoadScene("Menu");

    }


    // Oyunu durdur
    private void StopGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
    }
}
