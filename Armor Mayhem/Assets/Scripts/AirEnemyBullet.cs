using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyBulletScipt : MonoBehaviour
{
    float timer = 0f;
    float destroyTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On Collision with Player
        if(collision.gameObject.tag.Equals("Player") == true)
        {
            FindAnyObjectByType<GameManager>().GameOver();
            Destroy(gameObject);
        }

        // On Collision With Ground
        if(collision.gameObject.tag.Equals("Ground") == true)
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag.Equals("GroundEnemy") == true)
        {
            Destroy(gameObject);
        }
    }
}
