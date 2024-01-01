using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            Instantiate(enemy , new Vector3(Random.Range(-25 , 25) , 2 , 100) , Quaternion.identity);
            time = 0f;
        }
    }
}
