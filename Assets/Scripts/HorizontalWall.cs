using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HorizontalWall : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent OnBallHit { get; set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        OnBallHit?.Invoke();
    }

}
