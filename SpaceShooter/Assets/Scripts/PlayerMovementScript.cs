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
        if(Input.GetKey("a"))
        {
            playerBodyRB.AddForce(-playerSpeed * Time.deltaTime , 0 , 0 , ForceMode.VelocityChange);
        }
        if(Input.GetKey("d")) 
        {
            playerBodyRB.AddForce(playerSpeed * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }
    }
}
