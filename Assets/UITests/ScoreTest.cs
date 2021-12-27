using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ScoreTest
{

    [OneTimeSetUp]
    public void setup()
    {
        SceneManager.LoadScene("PlayScene",LoadSceneMode.Single);
    }

    [UnityTest]
    public IEnumerator ChangeScoreTest([NUnit.Framework.Random(1,500,5)]int score)
    {
        GameManager.Instance.RandomSeed();
        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("symbol next "+GameManager.Instance.symbol);
        GameManager.Instance.changeScore(score);
        Debug.Log("score next "+GameManager.Instance.score);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddScoreTest([NUnit.Framework.Random(1,500,5)]int score)
    {
        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("addscore at first "+GameManager.Instance._addScore);
        GameManager.Instance.addScroe(score);
        Debug.Log("score next "+GameManager.Instance.score);
        Debug.Log("addscore next "+GameManager.Instance._addScore);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator SubScoreTest([NUnit.Framework.Random(1,500,5)]int score)
    {
        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("subscore at first "+GameManager.Instance._subScore);
        GameManager.Instance.subScore(score);
        Debug.Log("score next "+GameManager.Instance.score);
        Debug.Log("subscore next "+GameManager.Instance._subScore);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator MulScoreTest([NUnit.Framework.Random(1,500,5)]int score)
    {
        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("mulscore at first "+GameManager.Instance._mulScore);
        GameManager.Instance.mulScore(score);
        Debug.Log("score next "+GameManager.Instance.score);
        Debug.Log("mulscore next "+GameManager.Instance._mulScore);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator DivScoreTest([NUnit.Framework.Random(1,500,5)]int score)
    {
        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("divscore at first "+GameManager.Instance._divScore);
        GameManager.Instance.divScore(score);
        Debug.Log("score next "+GameManager.Instance.score);
        Debug.Log("divscore next "+GameManager.Instance._divScore);
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

}
