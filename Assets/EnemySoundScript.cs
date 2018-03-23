using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundScript : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip walkLeftAudio;

    public AudioClip walkRightAudio;

    public AudioClip enemyHurtAudio;

    public AudioClip enemyAttackAudio;

    public AudioClip enemyWinAudio;

    void enemyWalkLeft()
    {
        audioSource.PlayOneShot(walkLeftAudio);
    }

    void enemyWalkRight()
    {
        audioSource.PlayOneShot(walkRightAudio);
    }

    void enemyHurt()
    {
        audioSource.PlayOneShot(enemyHurtAudio);
    }

    void enemyAttack()
    {
        audioSource.PlayOneShot(enemyAttackAudio);
    }

    void enemyWin()
    {
        audioSource.PlayOneShot(enemyWinAudio);
    }

}
