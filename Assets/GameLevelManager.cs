using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    private static int score;
    public Text text;
    public Text gameOverText;
    public int pointsToButterflyStartSearch = 100;
    private static bool isGameOver = false;
    private bool scanPath = true;

    void Update()
    {
        if (scanPath)
        {
            AstarPath.active.Scan();
            scanPath = false;
        }
        text.text = score.ToString();
        if (isGameOver)
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
            GameObject.Find("UI").GetComponent<GameOverScript>().EnableScreen(score);
        } else
        {
            gameOverText.enabled = false;
        }
    }

    public static void addScore(int amount)
    {
        if (!isGameOver)
        {
            score += amount;
        }
    }

    public static void removeScore(int amount)
    {
        if (!isGameOver)
        {
            score -= amount;
        }
    }

    public static void setGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }

    public static void resetScore()
    {
        score = 0;
        setGameOver(false);
    }

    public int getButterflyHelpPoints()
    {
        return pointsToButterflyStartSearch;
    }

    public int getScore()
    {
        return score;
    }

}
