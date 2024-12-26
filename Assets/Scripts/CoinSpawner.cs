using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Coin prefab'i
    public float spawnRate = 2f; // Coin'lerin olu�turulma s�resi (saniye)
    public float minY = -2f; // Coin'lerin minimum Y konumu
    public float maxY = 2f; // Coin'lerin maksimum Y konumu
    public float spawnX = 10f; // Coin'lerin X konumu (ekran�n d���nda ba�latabilirsiniz)

    void Start()
    {
        // Coin'leri d�zenli olarak spawn etmek i�in InvokeRepeating kullan�yoruz.
        InvokeRepeating("SpawnCoin", 1f, spawnRate);
    }

    void SpawnCoin()
    {
        if (coinPrefab == null)
        {
            Debug.LogWarning("Coin prefab is missing or destroyed.");
            return;
        }

        // Rastgele bir Y pozisyonu belirliyoruz.
        float randomY = Random.Range(minY, maxY);

        // Coin'i olu�turuyoruz.
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);
        GameObject spawnedCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        // Spawn edilen coin'i 10 saniye sonra yok et
        Destroy(spawnedCoin, 10f);
    }
}
