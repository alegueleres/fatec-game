using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

    public CombatScript combatScript;

    void OnTriggerEnter(Collider other)
    {
        if (EnemyScript.verifyAttack() && !EnemyScript.verifyDie() && other.tag == "Hero")
        {
            combatScript.removeHeroLife(5);
        }
    }
}
