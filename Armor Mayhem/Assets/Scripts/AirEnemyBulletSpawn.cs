using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyBulletSpawn : MonoBehaviour
{
    public GameObject airEnemyBullet;

    float timer = 0f;
    float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            GameObject enemyBullet = Instantiate(airEnemyBullet);
            enemyBullet.transform.position = transform.position;
            timer = 0f;
        }
    }
}
