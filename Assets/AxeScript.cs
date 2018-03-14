using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {

    public CombatScript combatScript;

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        if (EnemyScript.verifyAttack() && other.gameObject.tag == "Hero")
        {
            combatScript.removeHeroLife(5);
        }
    }
}
