using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    private static int score;
    public Text text;
    public bool isGameOver = false;
    private bool scanPath = true;

    void Start()
    {
        StartCoroutine(updateScoreManager(1f, 1));
    }

    void Update()
    {
        if (scanPath)
        {
            AstarPath.active.Scan();
            scanPath = false;
        }
        text.text = "Pontuação: " + score.ToString();
    }

    IEnumerator updateScoreManager(float totalTime, int amount)
    {
        while (!isGameOver)
        {
            addScore(amount);
            yield return new WaitForSeconds(1);
        }
    }

    public static void addScore(int amount)
    {
        score += amount;
    }

}
