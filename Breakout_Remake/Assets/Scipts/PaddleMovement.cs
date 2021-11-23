using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float BondariesWidth;

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        transform.position += move * speed * Time.deltaTime;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -BondariesWidth, BondariesWidth), -4);
    }
}
