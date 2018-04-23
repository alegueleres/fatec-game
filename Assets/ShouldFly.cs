using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ShouldFly : MonoBehaviour {

    public GameObject butterfly;

    public GameObject hero;

    public GameObject exitTarget;

    public Text butterflyText;

    public GameLevelManager gameLevelManager;

    private static bool shouldSearchExit = false;

    private static bool shouldResetSearch = true;

    private void Start()
    {
        butterflyText.text = "-" + gameLevelManager.getButterflyHelpPoints().ToString();
    }

    private void Update()
    {
        if(CrossPlatformInputManager.GetButton("Butterfly") && !shouldSearchExit && (gameLevelManager.getScore() - gameLevelManager.getButterflyHelpPoints()) >= 0)
        {
            shouldSearchExit = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (shouldSearchExit && collider.tag == "Hero")
        {
            AIPath aipath = butterfly.GetComponent<AIPath>();
            aipath.target = exitTarget.transform;
            if (shouldResetSearch)
            {
                GameLevelManager.removeScore(gameLevelManager.getButterflyHelpPoints());
                Invoke("resetSearchExit", 60);
                butterflyText.text = "Siga-me";
                shouldResetSearch = false;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Hero")
        {
            AIPath aipath = butterfly.GetComponent<AIPath>();
            aipath.target = hero.transform;
        }
    }

    private void resetSearchExit()
    {
        shouldSearchExit = false;
        shouldResetSearch = true;

        AIPath aipath = butterfly.GetComponent<AIPath>();
        aipath.target = hero.transform;
        butterflyText.text = "-" + gameLevelManager.getButterflyHelpPoints().ToString();
    }

}
