using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 600;
    Rigidbody2D _rigidbody2D;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    private SpriteRenderer _renderer;
    GameManager _gameManager;
    public AudioClip hurtSound;
    AudioSource _audioSource;

    Vector2 playView; 

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // creating 'world'
        Camera cam = Camera.main;
        playView = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        _renderer = GetComponent<SpriteRenderer>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    IEnumerator FlashRed() {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        _renderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") || other.CompareTag("BossBullet")) {
            _audioSource.PlayOneShot(hurtSound);
            _gameManager.loseLife(1);
            StartCoroutine(FlashRed());
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;

        // confine player to screen
        if (transform.position.x > playView.x)
        {
            xSpeed = Mathf.Clamp(xSpeed, -speed, 0);
        }
        else if (transform.position.x < -playView.x)
        {
            xSpeed = Mathf.Clamp(xSpeed, 0, speed); 
        }
        if (transform.position.y > playView.y)
        {
            ySpeed = Mathf.Clamp(ySpeed, -speed, 0); 
        }
        else if (transform.position.y < -playView.y)
        {
            ySpeed = Mathf.Clamp(ySpeed, 0, speed); 
        }



        _rigidbody2D.velocity = new Vector2(xSpeed,ySpeed);
        // fires when you hit the button
        if (Input.GetButtonDown("Jump")){
            // making a copy of bullet
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        }
    }
}