using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject creditsPanel;
    public PlayMusic playMusic;

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

    public void EnableCreditsScreen(int score)
    {
        creditsPanel.transform.Find("ScoreText").gameObject.GetComponent<Text>().text = score.ToString();
        creditsPanel.transform.Find("BestScoreText").gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
        creditsPanel.SetActive(true);
        Destroy(GameObject.Find("Canvas"));
        playMusic.FadeUp(.01f);
        playMusic.PlaySelectedMusic(3);
    }
}
