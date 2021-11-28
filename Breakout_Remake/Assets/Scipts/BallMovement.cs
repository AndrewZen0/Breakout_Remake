using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public static event Action<BallMovement> OnBallDeath;

    public void Die()
    {
        OnBallDeath?.Invoke(this);
        Destroy(gameObject, 1);
    }
}
