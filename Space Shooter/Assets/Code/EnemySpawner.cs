using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;    

    IEnumerator Start()
    {
        for (int i =0; i >=0; i++){
            Vector2 spawnPos = new Vector2(Random.Range(10.1f,10.6f),Random.Range(4.5f, -4.5f));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
        }
    }
    
}
