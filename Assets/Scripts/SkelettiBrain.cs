using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkelettiBrain : MonoBehaviour
{
    // Start is called before the first frame update
    

    const float MAX_SPEED = 5;
    const float STUN_DURATION = 2;
    const int MAX_HEALTH = 2;

    Transform player;
    Rigidbody2D body;
    Transform myTransform;

    public int health;
    bool stunned;
    float stunnedCooldown;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        stunned = false;
        stunnedCooldown = STUN_DURATION;

        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetVelocity = (player.position -  myTransform.position).normalized * MAX_SPEED ;

        stunnedCooldown -= Time.deltaTime;
        if (stunnedCooldown <= 0) {
            stunned = false;
            stunnedCooldown = 0;
        }

        if (!stunned) {
            body.velocity = body.velocity * 0.9f + targetVelocity * 0.1f;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.tag != "Player") {
            return;
        }
        
        SlimeJumpManual player = other.gameObject.GetComponent<SlimeJumpManual>();

        if (!stunned && !player.jumping) {
            player.health -= 1;
            if (player.health <= 0) {
                SceneManager.LoadScene("Outro", LoadSceneMode.Single);
            }
            return;
        }
        
        health -= 1;
        if (health <= 0) {
            Destroy(this.gameObject);
        }

        stunned = true;
        stunnedCooldown = STUN_DURATION;
    }
}
