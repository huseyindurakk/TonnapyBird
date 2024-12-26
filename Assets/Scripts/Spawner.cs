using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePairPrefab; // PipePair prefab
    public float spawnRate = 2f;      // Pipe spawn s�resi
    public float heightOffset = 2f;   // Rastgele y�kseklik aral���

    private float timer = 0;
    public bool isGameOver = false;   // Oyun biti� kontrol�

    void Update()
    {
        // E�er oyun bitmi�se boru spawn etmeyi durdur
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
        // Rastgele y�kseklik
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(5, randomY, 0);

        // PipePair olu�tur
        GameObject spawnedPipe = Instantiate(pipePairPrefab, spawnPosition, Quaternion.identity);

        // Spawnlanan nesneyi 10 saniye sonra yok et
        Destroy(spawnedPipe, 10f);
    }

    // Oyun bitti�inde spawner'� durdur
    public void StopSpawning()
    {
        isGameOver = true;
    }
}


