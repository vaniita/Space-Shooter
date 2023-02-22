using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerVertical : MonoBehaviour
{
    public GameObject enemyPrefab;
    IEnumerator Start()
    {
        for(int i = 0; i < 20; i++){
            Vector2 spawnPos = new Vector2(Random.Range(-10f, 10f), Random.Range(6, 10));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
