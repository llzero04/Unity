using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemySpawnScript : MonoBehaviour
{
    public GameObject airEnemy;

    float timer = 0f;
    float spawnTimer = 5f;

    Vector3 spawnOffset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTimer)
        {
            spawnOffset = Vector3.zero;
            float offset = Random.Range(-1f, 1f);
            spawnOffset.y += offset;
            GameObject instantiatedEnemy = Instantiate(airEnemy);
            instantiatedEnemy.transform.position = transform.position + spawnOffset;
            timer = 0f;
        }
    }
}
