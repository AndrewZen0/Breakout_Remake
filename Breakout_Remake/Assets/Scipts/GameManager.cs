using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance => _instance;



    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion

    public GameObject GameOverScreen;

    public GameObject VictoryScreen;

    public GameObject ScoreText;

    private GameObject[] Bricks;

    public int AvaliableLives = 3;
    public int Lives { get; set; }
    public bool IsGameStarted { get; set; }

    public int CurrentLevel;

    private void Start()
    {
        this.Lives = this.AvaliableLives;
        BallMovement.OnBallDeath += OnBallDeath;
        VictoryScreen.SetActive(false);
        ScoreText.SetActive(true);
        GameOverScreen.SetActive(false);

        if (Bricks == null)
        {
            Bricks = GameObject.FindGameObjectsWithTag("Brick");
        }

        ResumeGame();
    }

    private void Update()
    {
        Bricks = GameObject.FindGameObjectsWithTag("Brick");

        if (Bricks.GetLength(0) < 1)
        {
            PauseGame();
            VictoryScreen.SetActive(true);
        }
    }

    private void OnBallDeath(BallMovement obj)
    {
        this.Lives--;

        if(Lives < 1)
        {
            PauseGame();
            ScoreScript.scoreValue = 0;
            ScoreText.SetActive(false);
            GameOverScreen.SetActive(true);
        }
        else
        {
            //GameOverScreen.SetActive(false);
        }
    }

    public void RestartGame()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Game");        
    }

    private void OnDisable()
    {
        BallMovement.OnBallDeath -= OnBallDeath;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
