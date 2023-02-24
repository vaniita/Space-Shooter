using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletBehavior : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        if (transform.position.x <= -11) {
            Destroy(gameObject);
        }
    }
}
