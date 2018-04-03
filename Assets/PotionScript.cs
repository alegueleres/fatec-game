using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour {

    public AudioClip drink;

    private void OnTriggerEnter(Collider other)
    {
        CombatScript combatScript = GameObject.Find("EventSystem").GetComponent<CombatScript>();
        if(other.tag == "Hero" && combatScript.getHeroLife() < 5)
        {
            combatScript.addHeroLife(1);
            GameObject.Find("Hero").GetComponent<AudioSource>().PlayOneShot(drink);
            GameLevelManager.addScore(5);
            Destroy(this.gameObject);
        }
    }
}
