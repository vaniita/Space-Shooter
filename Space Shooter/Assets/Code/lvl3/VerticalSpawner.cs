using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSpawner : MonoBehaviour
{
    public GameObject verticalPrefab;
    public GameObject player;
    GameManager _gameManager;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        while (_gameManager.GetLives() > 0) {
            Vector2 spawnPos = new Vector2(Random.Range(-5,7), -6);
            Instantiate(verticalPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1,3));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
