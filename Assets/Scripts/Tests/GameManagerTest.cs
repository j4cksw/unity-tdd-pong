using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTest
{
    [Test]
    public void ShouldStartWithZeroScore()
    {
        // Arrange
        var gameManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gameManager = GameObject.Instantiate(gameManagerPrefab);
        
        // Assert
        Assert.AreEqual(0, gameManager.GetComponent<GameManager>().Player1Score);
    }
    
    [Test]
    public void IncreasingPlayer1ScoreWhenGetNotified()
    {
        // Arrange
        var gameManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gameManager = GameObject.Instantiate(gameManagerPrefab);
        // Act
        gameManager.GetComponent<GameManager>().IncreasePlayer1Score();
        // Assert
        Assert.AreEqual(1, gameManager.GetComponent<GameManager>().Player1Score);
    }
    
    [Test]
    public void IncreasingPlayer2ScoreWhenGetNotified()
    {
        // Arrange
        var gameManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gameManager = GameObject.Instantiate(gameManagerPrefab);
        // Act
        gameManager.GetComponent<GameManager>().IncreasePlayer2Score();
        // Assert
        Assert.AreEqual(1, gameManager.GetComponent<GameManager>().Player2Score);
    }
    
    [Test]
    public void ShouldNotifyWhenPlayer1GetScore()
    {
        // Arrange
        var gameManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gameManager = GameObject.Instantiate(gameManagerPrefab);
        // Act
        var notifiedScore = -1;
        gameManager.GetComponent<GameManager>().OnPlayer1ScoreUpdate.AddListener((score) => notifiedScore = score);
        gameManager.GetComponent<GameManager>().IncreasePlayer1Score();
        // Assert
        Assert.AreEqual(1, notifiedScore);
    }
    
    [Test]
    public void ShouldNotifyWhenPlayer2GetScore()
    {
        // Arrange
        var gameManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");
        var gameManager = GameObject.Instantiate(gameManagerPrefab);
        // Act
        var notifiedScore = -1;
        gameManager.GetComponent<GameManager>().OnPlayer2ScoreUpdate.AddListener((score) => notifiedScore = score);
        gameManager.GetComponent<GameManager>().IncreasePlayer2Score();
        // Assert
        Assert.AreEqual(1, notifiedScore);
    }
}
