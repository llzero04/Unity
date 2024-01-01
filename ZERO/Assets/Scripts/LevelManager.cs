using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int getLevel()
    {
        // Debug.Log("Level Manager " + level.ToString());
        return level;
    }

    public void incrementLevel(int val)
    {
        level += val;
    }
}
