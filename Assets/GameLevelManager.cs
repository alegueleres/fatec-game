using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour {

    private static int score;
    public Text text;
    public Text gameOverText;
    private static bool isGameOver = false;
    private bool scanPath = true;

    void Start()
    {
        StartCoroutine(losePoints());
    }

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

    IEnumerator losePoints()
    {
        while (true)
        {
            if (score > 0)
            {
                score -= 1;
            }
            yield return new WaitForSeconds(30);
        }
    }

}
