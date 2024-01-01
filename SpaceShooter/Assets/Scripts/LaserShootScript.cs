using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShootScript : MonoBehaviour
{
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && FindAnyObjectByType<GameManagerScript>().getAmmo() > 0) 
        {
            GameObject obj = Instantiate(laser , this.transform);
            obj.SetActive(true);
            FindAnyObjectByType<GameManagerScript>().incrementAmmo(-1);
        }
    }
}
