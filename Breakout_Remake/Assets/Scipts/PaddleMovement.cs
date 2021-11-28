using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    #region Singleton

    private static PaddleMovement _instance;

    public static PaddleMovement Instance => _instance;

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


    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        transform.position += move * speed * Time.deltaTime;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.7f), -4);
    }
}
