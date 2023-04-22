using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace PlayModeTests
{
    public class GameSceneTest: InputTestFixture
    {
        private GameObject _ball;
        private Keyboard _keyboard;
        
        public IEnumerator SetUpGameScene()
        {
            _keyboard = InputSystem.AddDevice<Keyboard>();
            SceneManager.LoadScene("Game");
            yield return null;
            _ball = GameObject.Find("Ball");
        }

        [UnityTest]
        public IEnumerator StartWithZeroScore()
        {
            yield return SetUpGameScene();
            Assert.AreEqual("0", GameObject.Find("Player1ScoreText").GetComponent<TextMeshProUGUI>().text);
            Assert.AreEqual("0", GameObject.Find("Player2ScoreText").GetComponent<TextMeshProUGUI>().text);
        }
        
        [UnityTest]
        public IEnumerator BallMovesWhenPressButton()
        {
            yield return SetUpGameScene();
            Assert.AreEqual(Vector3.zero, _ball.transform.position);
            
            Press(_keyboard.spaceKey);
            yield return new WaitForSeconds(.1f);
            
            Assert.AreNotEqual(Vector3.zero, _ball.transform.position);
        }

        [UnityTest]
        public IEnumerator Player1GetScoreWhenBallPassedTheRightWall()
        {
            yield return SetUpGameScene();
            _ball.GetComponent<BallTrigger>().Direction = Vector2.right;
            
            Press(_keyboard.spaceKey);
            //Time.timeScale = 100;
            yield return new WaitForSeconds(.1f);
            Assert.AreEqual("1", GameObject.Find("Player1ScoreText").GetComponent<TextMeshProUGUI>().text);
        }

        [UnityTest]
        public IEnumerator Player2GetScoreWhenBallPassedTheLeftWall()
        {
            // Arrange
            yield return SetUpGameScene();
            _ball.GetComponent<BallTrigger>().Direction = Vector2.left;
            // Act
            Press(_keyboard.spaceKey);
            //Time.timeScale = 100;
            yield return new WaitForSeconds(.1f);
            // Assert
            Assert.AreEqual("1", GameObject.Find("Player2ScoreText").GetComponent<TextMeshProUGUI>().text);
        }

        [UnityTest]
        public IEnumerator ResetBallPositionAndStateWhenPlayer1GetScore()
        {
            // Arrange
            yield return SetUpGameScene();
            _ball.GetComponent<BallTrigger>().Direction = Vector2.right;
            // Act
            Press(_keyboard.spaceKey);
            yield return new WaitForSeconds(.1f);
            // Assert
            Assert.AreEqual(Vector3.zero, _ball.transform.position);
        }
        
        [UnityTest]
        public IEnumerator ResetBallPositionAndStateWhenPlayer2GetScore()
        {
            // Arrange
            yield return SetUpGameScene();
            _ball.GetComponent<BallTrigger>().Direction = Vector2.left;
            // Act
            Press(_keyboard.spaceKey);
            yield return new WaitForSeconds(.1f);
            // Assert
            Assert.AreEqual(Vector3.zero, _ball.transform.position);
        }

        [UnityTest]
        public IEnumerator Player1PaddleMoveUpWhenPressUp()
        {
            yield return SetUpGameScene();
            
            Press(_keyboard.upArrowKey);
            yield return new WaitForSeconds(.1f);
            var paddle = GameObject.Find("Paddle");
            Assert.Greater(paddle.transform.position.y, 0);
        }
        
        [UnityTest]
        public IEnumerator Player1PaddleMoveDownWhenPressDown()
        {
            yield return SetUpGameScene();
            
            Press(_keyboard.downArrowKey);
            yield return new WaitForSeconds(.1f);
            var paddle = GameObject.Find("Paddle");
            Assert.Less(paddle.transform.position.y, 0);
        }
        
        public override void TearDown()
        {
            Object.Destroy(_ball);
            base.TearDown();
        }
    }
}
