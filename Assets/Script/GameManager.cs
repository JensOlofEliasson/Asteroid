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
    public GameObject asterioid;
    public GameObject asterioid2;
    public GameObject asterioid3;

    public int score;
    public int highScore;
    public bool isGameActive;

    private void Start()
    {
        player.gameObject.SetActive(false);
        asterioid.gameObject.SetActive(false);
        asterioid2.gameObject.SetActive(false);
        asterioid3.gameObject.SetActive(false);
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
        asterioid.gameObject.SetActive(true);
        asterioid2.gameObject.SetActive(true);
        asterioid3.gameObject.SetActive(true);
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
