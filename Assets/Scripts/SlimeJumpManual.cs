using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeJumpManual : MonoBehaviour
{
    Rigidbody2D body;

    public bool jumping;
    public int flowers;
    public int health;
    public float jumpSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        jumping = false;
        flowers = 0;
        health = 3;
    }

    void doJump () {
        if(body.velocity.magnitude <= 0.5) {
            jumping = false;
        }

        if (jumping) {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 

        Vector2 jumpDir = new Vector2(x, y);

        if (jumpDir.magnitude >= 0.1) {
            jumping = true;
            body.velocity = jumpDir * jumpSpeed;
        }
    }
    
    void Update () {
        doJump();
    }   

    void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag == "flower") && (flowers < 3)) {
            flowers += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "castle") {
            other.gameObject.GetComponent<SlimeSpawner>().addSlimes(flowers);
            flowers = 0;
        }
    }
}
