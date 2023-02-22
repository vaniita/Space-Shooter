using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBehavior : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public AudioClip hurtSound;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
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
        if (transform.position.x <= -11) {
            Destroy(gameObject);
        }
    }
}
