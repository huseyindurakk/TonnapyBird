using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePairPrefab; // PipePair prefab
    public float spawnRate = 2f;      // Pipe spawn süresi
    public float heightOffset = 2f;   // Rastgele yükseklik aralýðý

    private float timer = 0;
    public bool isGameOver = false;   // Oyun bitiþ kontrolü

    void Update()
    {
        // Eðer oyun bitmiþse boru spawn etmeyi durdur
        if (isGameOver)
            return;

        if (timer > spawnRate)
        {
            SpawnPipePair();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void SpawnPipePair()
    {
        // Rastgele yükseklik
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(5, randomY, 0);

        // PipePair oluþtur
        GameObject spawnedPipe = Instantiate(pipePairPrefab, spawnPosition, Quaternion.identity);

        // Spawnlanan nesneyi 10 saniye sonra yok et
        Destroy(spawnedPipe, 10f);
    }

    // Oyun bittiðinde spawner'ý durdur
    public void StopSpawning()
    {
        isGameOver = true;
    }
}


