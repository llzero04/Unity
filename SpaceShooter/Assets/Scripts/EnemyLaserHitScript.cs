using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserHitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") == true)
        {
            //Disable Player Movement and shoot script
            // Also disabling the enemy spawn script
            FindAnyObjectByType<PlayerMovementScript>().enabled = false;
            FindAnyObjectByType<LaserShootScript>().enabled = false;
            FindAnyObjectByType<EnemySpawn>().enabled = false;

            FindAnyObjectByType<GameManagerScript>().gameOver();
        }
    }
}
