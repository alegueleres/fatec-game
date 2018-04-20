using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
        Destroy(GameObject.Find("UI"));
        GameLevelManager.resetScore();
        CombatScript.resetHeroLife();
        PlayMusic.StopMusic();
        SceneManager.LoadScene("MainMenu");
        Pause.UnPause();
	}
}
