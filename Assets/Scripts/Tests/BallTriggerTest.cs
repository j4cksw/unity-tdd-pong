using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BallTriggerTest
    {
        [UnityTest]
        public IEnumerator ResetBallPositionWhenNotified()
        {
            var ballPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball.prefab");
            var ball = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            yield return null;
            
            ball.GetComponent<BallTrigger>().KickOff();
            yield return null;
            ball.GetComponent<BallTrigger>().Reset();
            
            Assert.AreEqual(Vector3.zero, ball.transform.position);
        }
        
        [UnityTest]
        public IEnumerator ResetKickOffStateWhenNotified()
        {
            var ballPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball.prefab");
            var ball = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            yield return null;
            
            ball.GetComponent<BallTrigger>().KickOff();
            yield return null;
            ball.GetComponent<BallTrigger>().Reset();
            
            Assert.AreEqual(false, ball.GetComponent<BallTrigger>().KickedOff);
        }
        
        [UnityTest]
        public IEnumerator ResetDirectionWhenNotified()
        {
            var ballPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Ball.prefab");
            var ball = GameObject.Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
            yield return null;

            var originDirection = ball.GetComponent<BallTrigger>().Direction;
            yield return null;
            ball.GetComponent<BallTrigger>().Reset();
            
            Assert.AreNotEqual(originDirection, ball.GetComponent<BallTrigger>().Direction);
        }
    }
}