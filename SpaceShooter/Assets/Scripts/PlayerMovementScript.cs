using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody playerBodyRB;
    public float playerSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.GetKey("a") || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerBodyRB.AddForce(-playerSpeed * Time.deltaTime , 0 , 0 , ForceMode.VelocityChange);
        }
        if(Input.GetKey("d") || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            playerBodyRB.AddForce(playerSpeed * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }
    }
}
