using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePunchScript : MonoBehaviour {

    private Animator heroAnimator;

    public GameObject enemy;

    private bool invincible;

    void Start()
    {
        heroAnimator = GameObject.Find("Hero").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (enemy.GetComponent<Animator>().GetBool("enemyAttack") && !enemy.GetComponent<Animator>().GetBool("enemyDied") && other.tag == "Hero" && !HeroMovements.verifyIfBlocking() && !invincible)
        {
            GameObject.Find("EventSystem").GetComponent<CombatScript>().removeHeroLife(1, enemy);
            invincible = true;
            Invoke("resetInvulnerability", 2);
        }
        if (other.tag == "Hero" && HeroMovements.verifyIfBlocking())
        {
            heroAnimator.SetTrigger(Animator.StringToHash("Blocked"));
        }
    }

    private void resetInvulnerability()
    {
        invincible = false;
    }
}
