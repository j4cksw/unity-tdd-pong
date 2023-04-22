using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeTests
{
    public class ScoreTextTest
    {
        [UnityTest]
        public IEnumerator UpdateScoreTextWhenNotified()
        {
            // Arrange
            var scoreTextPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ScoreText.prefab");
            var scoreText = GameObject.Instantiate(scoreTextPrefab);
            yield return null;
            // Act
            scoreText.GetComponent<ScoreText>().UpdateScore(1);
            // Assert
            Assert.AreEqual("1",scoreText.GetComponent<TextMeshProUGUI>().text);
        }
    }
}