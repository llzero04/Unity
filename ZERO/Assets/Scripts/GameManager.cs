using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CreateLevel createLevel;
    // public LevelManager levelManager;
    // public GameObject levelCompleteUI;
    //public TextAsset textAsset;

    // int level = 1;
    int maxLevel = 3;

    bool hasGameEnded = false;

    // string path = "Assets\\UserLevel.txt";

    // Start is called before the first frame update
    void Start()
    {
        hasGameEnded = false;
        /*
        StreamReader sr = new StreamReader(path);
        level = int.Parse(sr.ReadLine());
        sr.Close();
        */
        // level = int.Parse(textAsset.text);

        // createLevel.createLevelObjects();

        FindObjectOfType<Text>().text = "Level - " + FindObjectOfType<LevelManager>().getLevel().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void completeLevel()
    {
        // Debug.Log("Level Complete" + " " + FindObjectOfType<LevelManager>().getLevel().ToString());
        createLevel.onLevelComplete();
        FindObjectOfType<Text>().enabled = false;
        // GameObject.FindGameObjectWithTag("CompleteLevelUI").SetActive(true);
        // completeLevelUI.SetActive(true);
        // levelCompleteUI.SetActive(true);

        GameObject[] allGameObjects = (GameObject[])FindObjectsOfTypeAll(typeof(GameObject));
        for(int i = 0 ; i < allGameObjects.Length; i++)
        {
            if (allGameObjects[i].tag.Equals("CompleteLevelUI"))
            {
                allGameObjects[i].SetActive(true);
            }
        }

        FindObjectOfType<LevelManager>().incrementLevel(1);
        // levelManager.incrementLevel(1);
        
        // level += 1;
        // StreamWriter writer = new StreamWriter(path);
        // writer.Write(level.ToString());
        // writer.Close();
        
    }

    public void loadNextLevel()
    {
        if(FindObjectOfType<LevelManager>().getLevel() <= maxLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void restartLevel()
    {
        if(hasGameEnded == false)
        {
            Invoke("restartLevelUtil", 2f);
            hasGameEnded = true;
        }
    }

    void restartLevelUtil()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
