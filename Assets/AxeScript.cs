using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

    private Animator heroAnimator;

    public CombatScript combatScript;

    public GameObject hero;

    public GameObject enemy;

    private bool invincible;

    void Start()
    {
        heroAnimator = hero.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (enemy.GetComponent<Animator>().GetBool("enemyAttack") && !enemy.GetComponent<Animator>().GetBool("enemyDied") && other.tag == "Hero" && !HeroMovements.verifyIfBlocking() && !invincible)
        {
            combatScript.removeHeroLife(2, enemy);
            invincible = true;
            Invoke("resetInvulnerability", 2);
        }
        if(other.tag == "Hero" && HeroMovements.verifyIfBlocking())
        {
            heroAnimator.SetTrigger(Animator.StringToHash("Blocked"));
        }
    }

    private void resetInvulnerability()
    {
        invincible = false;
    }
}
