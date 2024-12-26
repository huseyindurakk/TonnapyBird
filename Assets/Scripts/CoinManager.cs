using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton referansý

    public TMP_Text coinText; // Coin UI referansý
    private int coinCount = 0; // Toplanan coin sayýsý

    void Awake()
    {
        // Singleton yapýsý
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
        coinCount += value; // Coin sayýsýný artýr
        UpdateCoinUI();
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
