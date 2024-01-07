using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    private float firingTime = 1f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*
            if(timer == 0f || timer > firingTime)
            {
                FireBulletObject();
            }
            timer += Time.deltaTime;
            return;
            */
            FireBulletObject();
        }

        // timer = 0f;
    }

    void FireBulletObject()
    {
        GameObject bulletObject = Instantiate(bullet);
        bulletObject.transform.position = gameObject.transform.position;
    }
}
