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
            Vector2 spawnPos = new Vector2(Random.Range(6.5f,8), Random.Range(-4.3f, 4.3f));
            Instantiate(calPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(.5f,1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
