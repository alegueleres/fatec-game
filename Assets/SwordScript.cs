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
            combatScript.removeEnemyLife(getDamage(), other.gameObject);
            PlayerCollisionScript.updateEnemyHP(other.gameObject, transform.position);
            invincible = true;
            Invoke("resetEnemyInvulnerability", 1.5f);
        }

    }

    private void resetEnemyInvulnerability()
    {
        invincible = false;
    }

    public static int getDamage()
    {
        return 2;
    }
}
