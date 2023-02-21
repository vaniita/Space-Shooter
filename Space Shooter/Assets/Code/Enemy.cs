using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int speed;
    int pointValue = 10;
    int lifeValue = 1;
    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    GameManager _gameManager;


    void Start()
    {
        speed = Random.Range(40,150);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed,0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet")){
            _gameManager.AddScore(pointValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Player")){
            print("HIT");
            _gameManager.loseLife(lifeValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Kill")){
            Destroy(gameObject);
        } 
    }

}
