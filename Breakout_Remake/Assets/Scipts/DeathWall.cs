using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            BallMovement ball = collision.GetComponent<BallMovement>();
            ball.Die();
        }
    }
}
