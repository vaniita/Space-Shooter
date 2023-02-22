using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    int speed;
    int pointValue = 10;
    int lifeValue = 1;
    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    GameManager _gameManager;
    string currentSceneName;
    public AudioClip hurtSound;
    AudioSource _audioSource;

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        speed = Random.Range(40,150);
        if (currentSceneName == "Level3") {
            speed = 200;
        }
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed,0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(lifeValue);
        }

        if (other.CompareTag("Kill")){
            Destroy(gameObject);
        } 
    }

}
