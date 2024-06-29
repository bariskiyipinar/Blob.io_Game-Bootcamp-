using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman_Oluşturma : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 10;
    public float spawnRadius = 50f; // Spawn edilecek alanın yarıçapı
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float rastgelex = Random.Range(-30f, 30f);
        float rastgelez = Random.Range(-30f, 30f);
        Vector3 position = new Vector3(rastgelex, transform.position.y, rastgelez);

        GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        newEnemy.GetComponent<Dusman>().SetManager(this); // Düşmanlara manager scriptini bildir
        enemies.Add(newEnemy);
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        enemies.Remove(enemy);
        SpawnEnemy(); // Yeni düşmanı doğur
    }
}
