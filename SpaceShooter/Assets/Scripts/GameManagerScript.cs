using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    int score = 0;
    int ammo = 0;

    public Text scoreText;
    public Text ammoText;
    public Text gameOverScore;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10; score = 0;
        changeScoreText();
        changeAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementScore(int increment)
    {
        score += increment;
        Debug.Log(score);
        changeScoreText();
    }

    void changeScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void incrementAmmo(int val)
    {
        ammo += val;
        changeAmmoText();
    }

    public void changeAmmoText()
    {
        ammoText.text = "Ammo : " + ammo.ToString();
    }

    public int getAmmo()
    { return ammo; }

    public void gameOver()
    {
        // GameObject gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        // gameOverUI.SetActive(true);

        gameOverUI.SetActive(true);
        gameOverScore.text = "Your score is " + score.ToString();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
