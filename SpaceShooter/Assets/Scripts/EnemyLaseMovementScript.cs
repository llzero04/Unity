using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaseMovementScript : MonoBehaviour
{
    public Rigidbody rbEnemyLaser;
    float enemyLaserSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemyLaser.AddForce(0, 0, -enemyLaserSpeed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < -50f)
        {
            Destroy(this.gameObject);
        }
    }
}
