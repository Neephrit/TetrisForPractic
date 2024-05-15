using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private Text textScore;
    [SerializeField] private GameObject txtScoreGmOj;
    [SerializeField] private Text textScoreGO;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    public int Score;

    private void Awake()
    {
        Time.timeScale = 1;
        Score = 0;
        gameOverScreen.SetActive(false);
        txtScoreGmOj.SetActive(true);
    }
    private void FixedUpdate()
    {
        textScore.text = "Score:" + Score;

        if(Input.GetKeyUp(KeyCode.Escape) && !gameOverScreen.active)
        {
            if (pauseScreen.active)
                Continue();
            else
                Pause();
        }
    }

    public void AddScore(int plusScore)
    {
        Score += plusScore;
    }

    public void Dead()
    {
        txtScoreGmOj.SetActive(false);
        gameOverScreen.SetActive(true);
        textScoreGO.text = "Score:" + Score;
        scoreManager.AddScore(new ScoreFix("Player", Score));
        Time.timeScale = 0;
    }
    private void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
