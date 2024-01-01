using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovementScript : MonoBehaviour
{
    public Rigidbody laserRigidBody;
    float laserSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        laserRigidBody.AddForce(0 , 0 , laserSpeed , ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > 100f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        
    }
}
