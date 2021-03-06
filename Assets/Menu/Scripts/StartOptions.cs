﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour {

	public int sceneToStart = 1;										//Index number in build settings of scene to load if changeScenes is true
	public bool changeScenes;											//If true, load a new scene when Start is pressed, if false, fade out UI and continue in single scene
	public bool changeMusicOnStart;										//Choose whether to continue playing menu music or start a new music clip
    public GameObject loadingScreen;
    public GameObject gameOverScreen;
    public GameObject creditsEndScreen;
    public Slider loadSlider;
    public Text loadProgressText;
    public Text waitText;
    public Text historyText;


    [HideInInspector] public bool inMainMenu = true;					//If true, pause button disabled in main menu (Cancel in input manager, default escape key)
	public Animator animColorFade; 					//Reference to animator which will fade to and from black when starting game.
	[HideInInspector] public Animator animMenuAlpha;					//Reference to animator that will fade out alpha of MenuPanel canvas group
	 public AnimationClip fadeColorAnimationClip;		//Animation clip fading to color (black default) when changing scenes
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;		//Animation clip fading out UI elements alpha


	private PlayMusic playMusic;										//Reference to PlayMusic script
	private float fastFadeIn = .01f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
	private ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels

	
	void Awake()
	{
		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

		//Get a reference to PlayMusic attached to UI object
		playMusic = GetComponent<PlayMusic> ();
        loadingScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        creditsEndScreen.SetActive(false);
    }


	public void StartButtonClicked()
	{
		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			playMusic.FadeDown(fadeColorAnimationClip.length);
		}

		//If changeScenes is true, start fading and change scenes halfway through animation when screen is blocked by FadeImage
		if (changeScenes) 
		{
			//Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
			Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);

			//Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
			//animColorFade.SetTrigger ("fade");
		} 

		//If changeScenes is false, call StartGameInScene
		else 
		{
			//Call the StartGameInScene function to start game without loading a new scene.
			StartGameInScene();
		}

	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += SceneWasLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneWasLoaded;
    }

    //Once the level has loaded, check if we want to call PlayLevelMusic
    void SceneWasLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playMusic.PlaySelectedMusic(0);
        }
    }


	public void LoadDelayed()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//Hide the main menu UI element
		showPanels.HideMenu ();
        if (changeMusicOnStart)
        {
            PlayNewMusic();
        }

        //Load the selected scene, by scene index number in build settings
        StartCoroutine(LoadAsynchronously(sceneToStart));
		//SceneManager.LoadScene (sceneToStart);
	}

	public void HideDelayed()
	{
		//Hide the main menu UI element after fading out menu for start game in scene
		showPanels.HideMenu();
	}

	public void StartGameInScene()
	{
		//Pause button now works if escape is pressed since we are no longer in Main menu.
		inMainMenu = false;

		//If changeMusicOnStart is true, fade out volume of music group of AudioMixer by calling FadeDown function of PlayMusic, using length of fadeColorAnimationClip as time. 
		//To change fade time, change length of animation "FadeToColor"
		if (changeMusicOnStart) 
		{
			//Wait until game has started, then play new music
			Invoke ("PlayNewMusic", fadeAlphaAnimationClip.length);
		}
		//Set trigger for animator to start animation fading out Menu UI
		animMenuAlpha.SetTrigger ("fade");
		Invoke("HideDelayed", fadeAlphaAnimationClip.length);
		Debug.Log ("Game started in same scene! Put your game starting stuff here.");
	}


	public void PlayNewMusic()
	{
		//Fade up music nearly instantly without a click 
		playMusic.FadeUp (fastFadeIn);
		//Play music clip assigned to mainMusic in PlayMusic script
		playMusic.PlaySelectedMusic (1);
	}

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        loadingScreen.SetActive(true);
        if (sceneIndex == 1)
        {
            historyText.text = "A borboleta Go está pronta para auxiliar em sua sobrevivência. Encontre o final do labirinto e fuja desse deserto traiçoeiro.";
        } else if (sceneIndex == 2)
        {
            historyText.text = "\"O que aconteceu? Como vim parar nesse lugar? Mas não desistirei, vamos Go! Encontraremos quem está fazendo isso conosco...\"";
        }

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            loadSlider.value = progress;
            loadProgressText.text = System.Math.Round(progress, 2) * 100 + "%";
            if (progress == 1)
            {
                waitText.text = "Toque para começar!";
                if( Input.GetButton("Fire1"))
                {
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }

        if(operation.isDone)
        {
            loadingScreen.SetActive(false);
            Pause.UnPause();
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        playMusic.FadeUp(fastFadeIn);
        playMusic.PlaySelectedMusic(sceneIndex);
        if (sceneIndex == 3)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
    }
}
