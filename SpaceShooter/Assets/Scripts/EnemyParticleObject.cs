using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleObject : MonoBehaviour
{
    float timer = 0f;
    float deathTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > deathTime)
        {
            Destroy(gameObject);
        }
    }
}
