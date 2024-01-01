using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO;

public class CreateLevel : MonoBehaviour
{
    // public GameManager gameManager;
    public GameObject obstacle;
    public GameObject endTrigger;
    // public LevelManager levelManager;

    float obstacleBufferLayer = 200f;
    float endBuffer = 100f;

    int platformWidth = 30;
    int platformLength;

    // string path = "Assets\\UserLevel.txt";

    void Start()
    {

        // int level = gameManager.getLevel();
        // StreamReader sr = new StreamReader(path);
        // int level = int.Parse(sr.ReadLine());

        int level = FindObjectOfType<LevelManager>().getLevel();

        platformLength = level * 500;
        int platformZPosition = platformLength/2 - 50;

        // Change Ground Position
        GameObject.FindGameObjectWithTag("Platform").transform.localScale = new Vector3(platformWidth, 1, platformLength + 500);
        GameObject.FindGameObjectWithTag("Platform").transform.position = new Vector3(0, 0, platformZPosition);

        float pos = obstacleBufferLayer;
        int obstaclesInLayer = 1;
        while(pos < platformLength - 50 - endBuffer)
        {
            for(int i = 0; i < obstaclesInLayer; i++)
            {
                Instantiate(obstacle, new Vector3(Random.Range(-14 , 14), 0, pos), Quaternion.Euler(0, Random.Range(-90f , 90f) , 0));
            }
            obstaclesInLayer += 1;
            pos += obstacleBufferLayer;
        }

        // Instantiate End Trigger
        Instantiate(endTrigger, new Vector3(0 , 250 , platformLength - endBuffer - 50), Quaternion.Euler(0, 0, 0));
        
    }

    public void onLevelComplete()
    {
        GameObject[] obstacleGameObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        for(int i = 0; i < obstacleGameObjects.Length; i++)
        {
            Destroy(obstacleGameObjects[i]);
        }

        GameObject[] endTriggerGameObjects = GameObject.FindGameObjectsWithTag("Finish");
        for(int i = 0; i < endTriggerGameObjects.Length; i++)
        {
            Destroy(endTriggerGameObjects[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
