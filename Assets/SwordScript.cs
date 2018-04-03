using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public CombatScript combatScript;

    private bool invincible;

    void OnTriggerEnter(Collider other)
    {
        if (HeroMovements.verifyIfAttack() && other.tag == "Enemy" && !invincible)
        {
            combatScript.removeEnemyLife(2, other.gameObject);
            invincible = true;
            Invoke("resetEnemyInvulnerability", 2);
        }
    }

    private void resetEnemyInvulnerability()
    {
        invincible = false;
    }
}
