using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
    public TextMeshProUGUI asteroidText;
    public TMP_InputField inputName;
    public string highScoreName;
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
        scoreText.gameObject.SetActive(false);
        score = 0;
        LoadHighScore();
        highScoreText.text = "HIGHSCORE: " + highScore + " " + highScoreName;
        asteroidText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
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
        if (score > highScore)
        {
            newHighScoreText.gameObject.SetActive(true);
            inputName.gameObject.SetActive(true);
        }
        else
        { 
            restartButton.gameObject.SetActive(true);
            highScoreText.gameObject.SetActive(true);
        }
        
    }

    public void NewHighScore()
    {
        highScoreName = inputName.text;
        newHighScoreText.gameObject.SetActive(false);
        inputName.gameObject.SetActive(false);
        highScore = score;
        highScoreText.text = "HIGHSCORE: " + score + " " +highScoreName;
        restartButton.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        SaveHighScore();
    }

    public void Play()
    {
        playButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        asteroidText.gameObject.SetActive(false);
        isGameActive = true;
        scoreText.gameObject.SetActive(true);
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

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }


}
