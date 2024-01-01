using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserSpawnScript : MonoBehaviour
{
    public GameObject enemyLaser;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 5f)
        {
            Instantiate(enemyLaser, this.transform);
            time = 0f;
        }
    }
}
