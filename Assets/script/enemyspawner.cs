using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public int maxEnemies = 10;
    private float timer;

    void Update()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.IsGameOver) return;
        if (enemyPrefabs == null || enemyPrefabs.Length == 0 ||
            spawnPoints == null || spawnPoints.Length == 0) return;
        timer += Time.deltaTime;
        if (timer < spawnInterval) return;
        timer = 0f;
        if (GameObject.FindGameObjectsWithTag("Enemy").Length
            >= maxEnemies) return;
        Transform point = spawnPoints[
            Random.Range(0, spawnPoints.Length)];
        GameObject enemy = enemyPrefabs[
            Random.Range(0, enemyPrefabs.Length)];
        if (point != null && enemy != null)
            Instantiate(enemy, point.position, Quaternion.identity);
    }
}
