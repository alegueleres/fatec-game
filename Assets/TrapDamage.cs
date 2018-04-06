using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            GameObject.Find("EventSystem").GetComponent<CombatScript>().removeHeroLifeFromTrap(1);
        }
    }
}
