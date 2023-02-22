using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFaceSpawnerHorizontal : MonoBehaviour
{
    public GameObject enemyPrefab;
    IEnumerator Start()
    {
        for(int i = 0; i < 100; i++){
            Vector2 spawnPos = new Vector2(-12.22f, Random.Range(-3.7f, 3.4f));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(7f);
        }
    }
}
