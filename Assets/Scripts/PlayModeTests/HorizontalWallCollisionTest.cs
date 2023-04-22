using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeTests
{
    public class HorizontalWallCollisionTest
    {
        [UnityTest]
        public IEnumerator FireHitEventWhenGetHit()
        {
            // Arrange
            var ballPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball.prefab");
            var wallPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HorizontalWall.prefab");
            
            var wall = GameObject.Instantiate(wallPrefab, new Vector3(1, 0, 0), Quaternion.identity);
            var isHit = false;
            wall.GetComponent<HorizontalWall>().OnBallHit.AddListener(() => isHit = true);
            
            // Act
            var ball = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            ball.GetComponent<CircleCollider2D>().radius = 1;
            
            // Assert
            yield return null;
            Assert.True(isHit);
        }
    }
}