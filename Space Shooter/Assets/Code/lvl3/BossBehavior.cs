using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    int spd;
    Rigidbody2D _rigidbody2D;
    public GameObject explosion;
    int ptVal = 1000;
    GameManager _gameManager;
    public AudioClip hurtSound;
    AudioSource _audioSource;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    int bulletSpd = 500;
    public AudioClip shootSound;
    public AudioClip hitSound;
    SpriteRenderer _renderer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spd = 100;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, spd));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<SpriteRenderer>();

        while (_gameManager.GetLives() > 0) {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpd, 0));
            _audioSource.PlayOneShot(shootSound);
            yield return new WaitForSeconds(Random.Range(.3f,1));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet")) {
            _audioSource.PlayOneShot(hitSound);
            StartCoroutine(FlashRed());
            _gameManager.BossTakeDmg(2);
            if (_gameManager.GetBossHealth() <= 0) {
                _gameManager.AddScore(ptVal);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            
        }
        if (other.CompareTag("Player")) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
        }
    }

    IEnumerator FlashRed() {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        _renderer.color = Color.white;
    }

    void Update() {
        if (_gameManager.GetLives() <= 0) {
            Destroy(gameObject);
        }
        else if (transform.position.y <= -3.2f) {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, spd));
        } else if (transform.position.y >= 3.2f) {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, -spd));
        }
    }
}
