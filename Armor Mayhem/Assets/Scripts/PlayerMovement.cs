using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;

    float playerSpeed = 2f;
    float maxSpeed = 5f;
    float jumpSpeed = 8f;
    bool jumpFlag = false;
    // 0 is right, 1 is left
    int direction = 0;
    // 0 is none, 1 is right, -1 is left
    int forceDirection = 0;

    Vector2 maxVelocity = Vector2.zero;
    Vector2 forceVector = Vector2.zero;

    private float deleteThresoldX = 10f;
    private float deleteThresoldY = 5.2f;

    bool isInAirFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        // Setting the maxVelocity
        maxVelocity = new Vector2 (maxSpeed, 0);
        forceVector = new Vector2(playerSpeed, 0);
        forceDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -1 * deleteThresoldX || transform.position.x > deleteThresoldX || transform.position.y < -1 * deleteThresoldY)
        {
            FindAnyObjectByType<GameManager>().GameOver();
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            jumpFlag = true;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // if(transform.rotation.y != -180) transform.Rotate(0 , 180 , 0);
            if(direction != 1)
            {
                // transform.Rotate(0, 180, 0);
                transform.rotation = Quaternion.Euler(0, -180f, 0);
                direction = 1;
            }
            forceDirection = -1;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            if(direction != 0)
            {
                // transform.Rotate(0, 180, 0);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                direction = 0;
            }
            forceDirection = 1;
        }
    }

    private void FixedUpdate()
    {
        if(jumpFlag)
        {
            if(!isInAirFlag)
            {
                Jump();
            }
            jumpFlag = false;
        }

        if(forceDirection != 0)
        {
            movePlayer();
            forceDirection = 0;
        }
    }

    void Jump()
    {
        playerRb.velocity = Vector2.zero;
        playerRb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        isInAirFlag = true;
    }

    void movePlayer()
    {
        playerRb.AddForce(forceVector * forceDirection * playerSpeed, ForceMode2D.Impulse);
        if(Mathf.Abs(playerRb.velocity.x) > maxVelocity.x)
        {
            playerRb.velocity = new Vector2(maxVelocity.x * forceDirection, playerRb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground") == true)
        {
            isInAirFlag = false;
        }
    }
}
