using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

    public CombatScript combatScript;

    private bool invincible;

    void OnTriggerEnter(Collider other)
    {
        if (EnemyScript.verifyAttack() && !EnemyScript.verifyDie() && other.tag == "Hero" && !HeroMovements.verifyIfBlocking() && !invincible)
        {
            combatScript.removeHeroLife(1);
            invincible = true;
            Invoke("resetInvulnerability", 1);
        }
    }

    private void resetInvulnerability()
    {
        invincible = false;
    }
}
