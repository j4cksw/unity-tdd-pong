using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    public void MoveUp()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + speed * Time.deltaTime, 
            transform.position.z);
    }

    public void MoveDown()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - speed * Time.deltaTime, 
            transform.position.z);
    }
}
