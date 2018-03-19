using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitApplication : MonoBehaviour {

	public void Quit()
	{
        SceneManager.LoadScene("MainMenu");
        Pause.UnPause();
	}
}
