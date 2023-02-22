using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if (transform.position.x >= 8) {
            Destroy(gameObject);
        }
    }
}
