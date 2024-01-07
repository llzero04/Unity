using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyMovement : MonoBehaviour
{
    public Rigidbody2D enemyRb;

    float enemySpeed = 3f;
    float maxEnemySpeed = 1f;
    Vector2 maxVelocity = Vector2.zero;

    private float deleteThresoldX = 10f;
    private float deleteThresoldY = 5.2f;

    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = new Vector2(maxEnemySpeed, 0);

        // Setting the initial velocity of the enemy
        enemyRb.velocity = maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy gameObject if out of bounds
        if (transform.position.x > deleteThresoldX || transform.position.x < deleteThresoldX * -1f || transform.position.y > deleteThresoldY || transform.position.y < -1f * deleteThresoldY)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        enemyRb.AddForce(new Vector2(enemySpeed, 0), ForceMode2D.Force);
        if(enemyRb.velocity.x > maxVelocity.x)
        {
            enemyRb.velocity = maxVelocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player") == true)
        {
            FindAnyObjectByType<GameManager>().GameOver();
        }
        if(collision.gameObject.tag.Equals("Bullet") == true)
        {
            FindAnyObjectByType<GameManager>().incrementScore(2);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // If Air Enemy Hits any ground object
        if(collision.gameObject.tag.Equals("Ground") == true)
        {
            Destroy(gameObject);
        }
    }
}
