using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimationScript : MonoBehaviour {

    public float seconds = 4;

    public Animation animationTrap;

    public AudioSource audioSource;

    public AudioClip attack;

    public AudioClip reload;

    private bool shouldPlay = true;
	
	// Update is called once per frame
	void Update () {
        if(shouldPlay)
        {
            animationTrap.Play();
            Invoke("resetShouldPlay", seconds);
            shouldPlay = false;
        }
    }
    
    void resetShouldPlay()
    {
        shouldPlay = true;
    }

    void trapAttack()
    {
        audioSource.PlayOneShot(attack);
    }

    void trapReload()
    {
        audioSource.PlayOneShot(reload);
    }
}
