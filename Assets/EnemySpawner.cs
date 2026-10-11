using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public int enemiesPerWave = 3;

    private int wave = 1;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            waveText.text = "Wave: " + wave;

            for (int i = 0; i < enemiesPerWave * wave; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnRate);
            }

            wave++;
            yield return new WaitForSeconds(5f); // break between waves
        }
    }

   public Transform[] spawnPoints;

   void SpawnEnemy()
   {
       int index = Random.Range(0, spawnPoints.Length);
    Transform spawnPoint = spawnPoints[index];

    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
}
}