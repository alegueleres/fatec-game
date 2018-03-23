using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSoundScript : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip walkLeftAudio;

    public AudioClip walkRightAudio;

    public AudioClip backLeftAudio;

    public AudioClip backRightAudio;

    public AudioClip heroHurtAudio;

    public AudioClip heroAttackAudio;

    public AudioClip heroBlockAudio;

    public AudioClip heroDeathOneAudio;

    public AudioClip heroDeathTwoAudio;

    void heroWalkLeft()
    {
        audioSource.PlayOneShot(walkLeftAudio);
    }

    void heroWalkRight()
    {
        audioSource.PlayOneShot(walkRightAudio);
    }

    void heroAttack()
    {
        audioSource.PlayOneShot(heroAttackAudio);
    }

    void heroBackLeft()
    {
        audioSource.PlayOneShot(backLeftAudio);
    }

    void heroBackRight()
    {
        audioSource.PlayOneShot(backRightAudio);
    }

    void heroHurt()
    {
        audioSource.PlayOneShot(heroHurtAudio);
    }

    void heroBlock()
    {
        audioSource.PlayOneShot(heroBlockAudio);
    }

    void heroDeathOne()
    {
        audioSource.PlayOneShot(heroDeathOneAudio);
    }

    void heroDeathTwo()
    {
        audioSource.PlayOneShot(heroDeathTwoAudio);
    }
}
