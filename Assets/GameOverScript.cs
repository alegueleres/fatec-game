using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public GameObject gameOverPanel;

    public void EnableScreen(int score)
    {
        gameOverPanel.transform.Find("ScoreText").gameObject.GetComponent<Text>().text = score.ToString();
        gameOverPanel.transform.Find("BestScoreText").gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void DisableScreen()
    {
        gameOverPanel.SetActive(false);
    }
}
