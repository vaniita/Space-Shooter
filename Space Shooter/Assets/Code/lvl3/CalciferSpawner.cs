using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalciferSpawner : MonoBehaviour
{
    public GameObject calPrefab;
    public GameObject player;
    GameManager _gameManager;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        while (_gameManager.GetLives() > 0) {
            Vector2 spawnPos = new Vector2(Random.Range(3.5f,8.5f), Random.Range(-4.5f, 4.5f));
            Instantiate(calPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(.3f,1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
