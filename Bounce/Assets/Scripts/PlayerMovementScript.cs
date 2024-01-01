using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    float playerSpeed = 10f;
    float jumpForce = 10f;

    bool isInAir = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Restart Level if Player falls off the edge
        if(gameObject.transform.position.y < -20f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetKey("w"))
        {
            playerRigidBody.AddForce(0, 0, playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKey("a"))
        {
            playerRigidBody.AddForce(-playerSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("d"))
        {
            playerRigidBody.AddForce(playerSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("s"))
        {
            playerRigidBody.AddForce(0, 0, -playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isInAir == false) Jump();
            // this.transform.position = this.transform.up * 2;
            // playerRigidBody.AddForce(this.transform.up)
            // playerRigidBody.AddForce(0, jumpForce, 0, ForceMode.Force);
            // playerRigidBody.AddForce(this.transform.up * jumpForce, ForceMode.Force);
        }
    }

    private void Jump()
    {
        // Reset y Velocity
        playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, 0f, playerRigidBody.velocity.z); // This makes sure that we will always jump the exact same height

        playerRigidBody.AddForce(0, jumpForce, 0, ForceMode.Impulse);

        isInAir = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Platform") == true)
        {
            isInAir = false;
        }
    }

    public void  killPlayerVelocity()
    {
        playerRigidBody.velocity = new Vector3(0f, 0f, 0f);
        gameObject.transform.rotation = Quaternion.identity;
    }
}
