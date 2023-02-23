using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    int speed = 50;
    public int pointValue = 1;
    int lifeValue = 1;
    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    GameManager _gameManager;

    void Start()
    {
        speed = Random.Range(40, 100);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -speed));
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
            _gameManager.loseLife(lifeValue);
        }

        if (other.CompareTag("Kill")){
            _gameManager.AddScore(-10);
            Destroy(gameObject);
        } 
    }
}
