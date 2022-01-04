using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    #region Singleton

    private static BallsManager _instance;

    public static BallsManager Instance => _instance;

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

    [SerializeField] private BallMovement ballPrefab;

    private BallMovement initialBall;

    private Rigidbody2D initialBallRb;

    public float initialBallSpeed = 250;

    public void Start()
    {
        InitBall();
    }

    private void Update()
    {
        if(!GameManager.Instance.IsGameStarted)
        {
            Vector3 paddlePosition = PaddleMovement.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + 0.27f, 0);
            initialBall.transform.position = ballPosition;

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    initialBallRb.isKinematic = false;
                    initialBallRb.AddForce(new Vector2(0, initialBallSpeed));
                    GameManager.Instance.IsGameStarted = true;
                }
            }
        }
    }

    private void InitBall()
    {
        Vector3 paddlePosition = PaddleMovement.Instance.gameObject.transform.position;
        Vector3 startingPoint = new Vector3(paddlePosition.x, paddlePosition.y + 0.27f, 0);
        initialBall = Instantiate(ballPrefab, startingPoint, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();
    }
}
