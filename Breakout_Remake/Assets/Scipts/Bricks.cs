using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bricks : MonoBehaviour
{
    public float posX = 9.6f;
    public float posY = 9.6f;
    public float posZ = 9.6f;

    public void ChangePosition()
    {
        transform.position = new Vector3(transform.position.x + posX, transform.position.y + posY, transform.position.z + posZ);
    }
}
