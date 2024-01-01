using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public Rigidbody enemyRigidBody;
    float enemySpeed = 8f;

    //public GameObject enemyLaser;
    //float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody.AddForce(0, 0, -enemySpeed , ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < -50f)
        {
            Destroy(gameObject);
        }

        //time += Time.deltaTime;
        //if(time > 3f) 
        //{
            //Instantiate(enemyLaser , new Vector3(0 , this.transform.position.y , this.transform.position.z - 1) , Quaternion.identity);
            //time = 0f;
        //}
    }
}
