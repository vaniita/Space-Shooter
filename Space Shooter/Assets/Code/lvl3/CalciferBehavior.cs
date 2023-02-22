using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalciferBehavior : MonoBehaviour
{
    int spd;
    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    int ptVal = 10;
    GameManager _gameManager;
    public AudioClip hurtSound;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spd = Random.Range(40,150);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-spd, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            _gameManager.AddScore(ptVal);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player")) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
        }
    }

    void Update() {
        if (transform.position.x <= -9.5f || _gameManager.GetLives() <= 0) {
            if (transform.position.x <= -9.5f) {
                _gameManager.AddScore(-(ptVal/2));
            }
            Destroy(gameObject);
        }
    }
}
