using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float ballSpeed =1.0f;
       // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20*rand, -15*rand)*ballSpeed); // y= -15

        }
        else
        {
            rb2d.AddForce(new Vector2(-20*rand, -15*rand)*ballSpeed); //y=-15
        }
    }
    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x ;
            vel.y = ((rb2d.linearVelocity.y/2) + (coll.collider.attachedRigidbody.linearVelocity.y/3));
            
            if (vel.y > -1.0 && vel.y < 1.0)
            {
                vel.y = 2.0f;
            }

            ballSpeed += 0.0001f;
            rb2d.linearVelocity = vel;

        }
    }
}
