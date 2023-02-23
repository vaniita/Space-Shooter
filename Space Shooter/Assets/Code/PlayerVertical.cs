using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVertical : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 600;
    Rigidbody2D _rigidbody2D;
    public Transform spawnPoint;
    public GameObject bulletPrefab;

    Vector2 playView; 

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // creating 'world'
        Camera cam = Camera.main;
        playView = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
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
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletSpeed));
        }
    }
}