using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimationScript : MonoBehaviour {

    public float seconds = 4;

    public Animation animation;

    private bool shouldPlay = true;
	
	// Update is called once per frame
	void Update () {
        if(shouldPlay)
        {
            animation.Play();
            Invoke("resetShouldPlay", seconds);
            shouldPlay = false;
        }
    }
    
    void resetShouldPlay()
    {
        shouldPlay = true;
    }
}
