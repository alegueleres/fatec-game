using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;				            //Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel
    public GameObject creditsPanel;                         //Store a reference to the Game Object CreditsPanel
    public GameObject creditsTint;							//Store a reference to the Game Object CreditsTint 
    public AudioMixer audioMixer;


    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
        optionsPanel.transform.Find("CreditsBack").gameObject.SetActive(false);
        if (GetMusicLevel() == -80f)
        {
            optionsPanel.transform.Find("OptionsMusicOff").gameObject.SetActive(true);
            optionsPanel.transform.Find("OptionsMusicOn").gameObject.SetActive(false);
        }
        else
        {
            optionsPanel.transform.Find("OptionsMusicOff").gameObject.SetActive(false);
            optionsPanel.transform.Find("OptionsMusicOn").gameObject.SetActive(true);
        }
    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        if (!creditsPanel.active && !creditsTint.active)
        {
            optionsPanel.SetActive(false);
            optionsTint.SetActive(false);
        }
	}

    //Call this function to activate and display the Credits panel during the main menu
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true);
        creditsTint.SetActive(true);
        optionsPanel.transform.Find("CreditsBack").gameObject.SetActive(true);
        optionsPanel.transform.Find("Credits").gameObject.SetActive(false);
    }

    //Call this function to deactivate and hide the Credits panel during the main menu
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false);
        creditsTint.SetActive(false);
        optionsPanel.transform.Find("Credits").gameObject.SetActive(true);
        optionsPanel.transform.Find("CreditsBack").gameObject.SetActive(false);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
        if (GetMusicLevel() == -80f)
        {
            pausePanel.transform.Find("OptionsMusicOff").gameObject.SetActive(true);
            pausePanel.transform.Find("OptionsMusicOn").gameObject.SetActive(false);
        } else
        {
            pausePanel.transform.Find("OptionsMusicOff").gameObject.SetActive(false);
            pausePanel.transform.Find("OptionsMusicOn").gameObject.SetActive(true);
        }
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);
	}

    public float GetMusicLevel()
    {
        float value = -80f;
        bool result = audioMixer.GetFloat("musicVol", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return -10f;
        }
    }
}
