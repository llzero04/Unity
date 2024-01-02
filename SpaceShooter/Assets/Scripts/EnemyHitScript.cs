using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitScript : MonoBehaviour
{
    public GameObject enemyDestroyParticle;

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
        if(other.gameObject.tag.Equals("Laser") == true)
        {
            GameObject.Instantiate(enemyDestroyParticle, transform.position, Quaternion.Euler(270, 0, 0));
            // GameObject newParticleSystem = Instantiate(enemyDestroyParticle);
            // newParticleSystem.transform.position = gameObject.transform.position;

            FindAnyObjectByType<GameManagerScript>().incrementScore(100);
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
            // Increment Ammo for destroying enemy
            FindAnyObjectByType<GameManagerScript>().incrementAmmo(5);

            FindAnyObjectByType<AudioManager>().PlayAudio("EnemyDestroyed");
        }
        else if(other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Game Over");
            //Disable Player Movement and shoot script
            // Disable the enemy spawn script
            FindAnyObjectByType<PlayerMovementScript>().enabled = false;
            FindAnyObjectByType<LaserShootScript>().enabled = false;
            FindAnyObjectByType<EnemySpawn>().enabled = false;

            // Trigger End Game method from game manager script
            FindAnyObjectByType<GameManagerScript>().gameOver();
        }
    }
}
