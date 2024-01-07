using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemySpawnScipt : MonoBehaviour
{
    public GameObject groundEnemy;

    float timer = 0f;
    float spawnTime = 5f;
    float spawnTimeDecrement = 0.05f;

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
            GameObject instantiatedEnemy = Instantiate(groundEnemy);
            instantiatedEnemy.transform.position = transform.position;
            timer = 0f;
        }
    }
}
