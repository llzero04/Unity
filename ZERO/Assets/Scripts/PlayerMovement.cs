using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementForce = 40f;
    public float forwardForce = 20f;
    public float jumpForce = 100f;

    public Rigidbody rb;

    public bool isJumpComplete = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(0 , 0 , forwardForce * Time.deltaTime , ForceMode.VelocityChange);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("d")) 
        {
            rb.AddForce(movementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isJumpComplete) {
                isJumpComplete = false;
                rb.AddForce(0 , jumpForce * Time.deltaTime , 0 , ForceMode.VelocityChange);
            }
        }
        */
        
        if(rb.position.y < -20f)
        {
            FindObjectOfType<GameManager>().restartLevel();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag.Equals("Platform"))
        {
            isJumpComplete = true;
        }
    }
}
