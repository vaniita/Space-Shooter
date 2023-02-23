using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerVertical : MonoBehaviour
{
    public GameObject enemyPrefab;
    IEnumerator Start()
    {
        for(int i = 0; i < 100; i++){
            Vector2 spawnPos = new Vector2(Random.Range(-9f, 9f), Random.Range(6, 10));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
