using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFaceHorizontal : MonoBehaviour
{
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;
    Vector2 startSpeed = new Vector2(3, 0);
    Vector2 endSpeed = new Vector2(25, 0);
    void Start()
    {
         _rigidbody2D = GetComponent<Rigidbody2D>();
         _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            _gameManager.ReduceHealthText();
            _gameManager.loseLife(1);
        }
        if (other.CompareTag("Kill")){
            Destroy(gameObject);
        } 
    }

    void Update()
    {
        if(transform.position.x < -8.5f){
            _rigidbody2D.velocity = startSpeed;
        }
        else{
            _rigidbody2D.velocity = endSpeed;
        }
    }
}
