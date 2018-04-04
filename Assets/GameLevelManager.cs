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

    void Update()
    {
        if (scanPath)
        {
            AstarPath.active.Scan();
            scanPath = false;
        }
        text.text = "Pontuação: " + score.ToString();
        if (isGameOver)
        {
            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
            }
            gameOverText.enabled = true;
            gameOverText.text = "Você perdeu. \nPontuação: " + score.ToString() + ". Sua maior pontuação foi: " + PlayerPrefs.GetInt("highscore");
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
    }

}
