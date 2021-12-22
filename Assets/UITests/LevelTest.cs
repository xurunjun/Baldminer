using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class LevelTest
{

    [OneTimeSetUp]
    public void setup()
    {
        SceneManager.LoadScene("PlayScene", LoadSceneMode.Single);
    }

    [UnityTest]
    [Repeat(10)]
    public IEnumerator SpeedTest()
    {
        GameManager.Instance.RandomSeed();
        GenerateManager.Instance.maxItem = 0;

        Debug.Log("before levelup " + Player.Instance._addLevel);
        Debug.Log("current speed" + Player.Instance.currentSpeed);

        Player.Instance.LevelUp(Player.LevelType.SPEED);
        Debug.Log("After levelup " + Player.Instance._addLevel);
        Debug.Log("current speed" + Player.Instance.currentSpeed);
        Player.Instance.Fire(new Vector2(Random.Range(0, 1440), Random.Range(0,2960)), 0);
        while (Player.Instance.isFire || Player.Instance.isBack)
        {
            yield return null;
        }
    }

    [UnityTest]
    [Repeat(10)]
    public IEnumerator SizeTest()
    {
        GameManager.Instance.RandomSeed();
        GenerateManager.Instance.maxItem = 0;
        Player.Instance.currentSpeed=3;

        Debug.Log("before levelup " + Player.Instance._subLevel);
        Debug.Log("current size" + Player.Instance.currentSize);

        Player.Instance.LevelUp(Player.LevelType.SIZE);
        Debug.Log("After levelup " + Player.Instance._subLevel);
        Debug.Log("current size" + Player.Instance.currentSize);
        Player.Instance.Fire(new Vector2(Random.Range(0, 1440), Random.Range(0,2960)), 0);
        while (Player.Instance.isFire || Player.Instance.isBack)
        {
            yield return null;
        }
    }

    [UnityTest]
    [Repeat(10)]
    public IEnumerator MagnTest()
    {
        GenerateManager.Instance.maxItem = 0;

        Debug.Log("before levelup " + Player.Instance._mulLevel);
        Debug.Log("current size" + Player.Instance.currentMagn);

        Player.Instance.LevelUp(Player.LevelType.MAGN);
        Debug.Log("After levelup " + Player.Instance._mulLevel);
        Debug.Log("current size" + Player.Instance.currentMagn);

        testMage();

        yield return null;
    }

    private void testMage()
    {
        GameManager.Instance.score=1;
        int score = Random.Range(1,5);
        Debug.Log("score to comulcate  "+score);

        Debug.Log("score at first "+GameManager.Instance.score);
        Debug.Log("symbol next "+GameManager.Instance.symbol);
        GameManager.Instance.changeScore(score);
        Debug.Log("score next "+GameManager.Instance.score);
    }

    [UnityTest]
    [Repeat(10)]
    public IEnumerator CostTest()
    {
        GenerateManager.Instance.maxItem = 0;

        Debug.Log("before levelup " + Player.Instance._divLevel);
        Debug.Log("current size" + Player.Instance.currentCost);

        Player.Instance.LevelUp(Player.LevelType.COST);
        Debug.Log("After levelup " + Player.Instance._divLevel);
        Debug.Log("current size" + Player.Instance.currentCost);
        yield return null;
    }
}
