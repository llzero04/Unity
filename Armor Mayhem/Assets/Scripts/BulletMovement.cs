using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float bulletSpeed = 10f;
    public Rigidbody2D bulletRb;

    private float deleteThresoldX = 10f;
    private float deleteThresoldY = 5.2f;

    float timer = 0;
    float killTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        bulletRb.AddForce(player.transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > deleteThresoldX || transform.position.x < -1 * deleteThresoldX || transform.position.y > deleteThresoldY || transform.position.y < -1 * deleteThresoldY)
        {
            // delete the game object
            Destroy(gameObject);
        }

        timer += Time.deltaTime;
        if(timer > killTimer )
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground") == true)
        {
            Destroy(gameObject);
        }
    }
}
