using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeTests
{
    public class VerticalWallCollisionTest
    {
        [UnityTest]
        public IEnumerator FlipYDirectionWhenBallHitTheTopWall()
        {
            // Arrange
            var ballPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball.prefab");
            var wallPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/VerticalWall.prefab");
            yield return null;
            
            var wall = GameObject.Instantiate(wallPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            var ball = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            
            // Act
            var originDirection = ball.GetComponent<BallTrigger>().Direction;
            yield return null;
            ball.GetComponent<CircleCollider2D>().radius = 1;
            
            // Assert
            yield return new WaitForSeconds(.01f);
            Assert.AreEqual(originDirection.x, ball.GetComponent<BallTrigger>().Direction.x);
            Assert.AreEqual(-(originDirection.y), ball.GetComponent<BallTrigger>().Direction.y);
        }
    }
}