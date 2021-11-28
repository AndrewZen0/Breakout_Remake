using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickCollision : MonoBehaviour
{
    public int hitPoint = 1;

    public static event Action<BrickCollision> OnBrickDestruction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
        ApplyCollisionMechanic(ball);
    }

    private void ApplyCollisionMechanic(BallMovement ball)
    {
        this.hitPoint--;

        if(this.hitPoint <= 0)
        {
            OnBrickDestruction?.Invoke(this);
            Destroy(this.gameObject);
        }
    }
}
