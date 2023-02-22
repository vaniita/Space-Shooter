using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemyBehavior : MonoBehaviour
{
    int spd;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public AudioClip hurtSound;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spd = Random.Range(500,1000);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, spd));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
        }
    }

    void Update() {
        if (transform.position.x >= 4.3f || _gameManager.GetLives() <= 0) {
            Destroy(gameObject);
        }
    }
}
