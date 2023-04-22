using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class BallTrigger : MonoBehaviour
{
    [field: SerializeField] public bool KickedOff { get; private set; }
    
    [field: SerializeField]
    public Vector2 Direction { get; set; }

    [field: SerializeField] public float Speed = 10f;

    private void Awake()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        if (KickedOff)
        {
            var transform1 = transform;
            transform1.position = transform1.position + (Vector3)Direction * (Time.deltaTime * Speed);
        }
    }

    public void KickOff()
    {
        KickedOff = true;
    }

    public void Reset()
    {
        KickedOff = false;
        transform.position = Vector3.zero;
        Direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("VertcalWall"))
        {
            Direction = new Vector2(Direction.x, -(Direction.y));
        }
    }
}
