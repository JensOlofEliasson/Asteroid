using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Button playButton;
    public Button exitButton;
    public Button restartButton;
    public GameObject player;
    public GameObject asteroid;
    public GameObject asteroid2;
    public GameObject asteroid3;

    public int score;
    public int highScore;
    public bool isGameActive;

    private void Start()
    {
        isGameActive = false;
        player.gameObject.SetActive(false);
        asteroid.gameObject.SetActive(false);
        asteroid2.gameObject.SetActive(false);
        asteroid3.gameObject.SetActive(false);
        score = 0;
        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "HIGHSCORE: " + score;
        }
        
    }

    public void Play()
    {
        playButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        isGameActive = true;
        player.gameObject.SetActive(true);
        asteroid.gameObject.SetActive(true);
        asteroid2.gameObject.SetActive(true);
        asteroid3.gameObject.SetActive(true);
    }

    public void Exit()   
    {       
        EditorApplication.ExitPlaymode();
        Application.Quit();
          
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
