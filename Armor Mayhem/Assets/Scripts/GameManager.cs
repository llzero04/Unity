using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;

    private int score = 0;
    private int highScore = 0;
    private string highScoreKey = "HighScore";

    private void Start()
    {
        // Stop the audio of the home screen
        FindAnyObjectByType<AudioManager>().stopAudio("HomeBackground");

        // Play the game background theme
        FindAnyObjectByType<AudioManager>().playAudio("GameBackgroundTheme");

        score = 0;
        scoreText.text = "Score : 0";
        // highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    private void Update()
    {
        
    }

    public void GameOver()
    {
        FindAnyObjectByType<AudioManager>().stopAudio("GameBackgroundTheme");
        FindAnyObjectByType<AudioManager>().playAudio("GameOver");

        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7f), ForceMode2D.Impulse);
        player.GetComponent<Collider2D>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.transform.Rotate(new Vector3(180, 0, 0), Space.World);

        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScore = highScore >= score ? highScore : score;
        PlayerPrefs.SetInt(highScoreKey, highScore);

        // Enable Game Over UI
        scoreText.text = "";
        gameOverScoreText.text = "Your score is : " + score.ToString();
        gameOverHighScoreText.text = "Your high score is : " + highScore.ToString();

        gameOverPanel.SetActive(true);
    }

    public void incrementScore(int val)
    {
        score += val;
        scoreText.text = "Score : " + score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
