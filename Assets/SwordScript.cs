using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public CombatScript combatScript; 

    void OnTriggerEnter(Collider other)
    {
        if (HeroMovements.verifyIfAttack() && other.tag == "Enemy")
        {
            combatScript.removeEnemyLife(3);
        }
    }
}
