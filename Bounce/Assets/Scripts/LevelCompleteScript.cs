using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player") == true)
        {
            FindAnyObjectByType<PlayerMovementScript>().killPlayerVelocity();
            // Debug.Log("Finish");

            // Load next level
            FindAnyObjectByType<GameManager>().LoadNextLevel();
        }
    }
}
