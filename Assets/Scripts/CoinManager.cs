using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton referans�

    public TMP_Text coinText; // Coin UI referans�
    private int coinCount = 0; // Toplanan coin say�s�

    void Awake()
    {
        // Singleton yap�s�
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoin(int value)
    {
        coinCount += value; // Coin say�s�n� art�r
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
