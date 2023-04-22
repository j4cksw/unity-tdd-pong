using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int Player1Score { get; private set; }
    
    [field: SerializeField]
    public UnityEvent<int> OnPlayer1ScoreUpdate { get; set; }

    public int Player2Score { get; private set; }
    
    [field: SerializeField]
    public UnityEvent<int> OnPlayer2ScoreUpdate { get; set; }

    public void IncreasePlayer2Score()
    {
        Player2Score++;
        OnPlayer2ScoreUpdate?.Invoke(Player2Score);
    }
    
    public void IncreasePlayer1Score()
    {
        Player1Score++;
        OnPlayer1ScoreUpdate?.Invoke(Player1Score);
    }
}
