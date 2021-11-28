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

    public int AvaliableLives = 3;
    public int Lives { get; set; }
    public bool IsGameStarted { get; set; }

    public int CurrentLevel;

    private void Start()
    {
        this.Lives = this.AvaliableLives;
        BallMovement.OnBallDeath += OnBallDeath;
        GameOverScreen.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void OnBallDeath(BallMovement obj)
    {
        this.Lives--;

        if(Lives < 1)
        {
            GameOverScreen.SetActive(true);
        }
        else
        {
            //GameOverScreen.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnDisable()
    {
        BallMovement.OnBallDeath -= OnBallDeath;
    }   
}
