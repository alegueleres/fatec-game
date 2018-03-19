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
            gameOverText.text = "Você perdeu. \nPontuação: " + score.ToString();
        }
    }

    public static void addScore(int amount)
    {
        score += amount;
    }

    public static void removeScore(int amount)
    {
        score -= amount;
    }

    public static void setGameOver(bool gameOver)
    {
        isGameOver = gameOver;
    }

}
