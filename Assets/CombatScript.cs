using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour {

    private Animator heroAnimator;

    private Animator enemyAnimator;

    public GameObject hero;

    public GameObject enemy;

    public int heroLife = 10;

    public int enemyLife = 20;
	
	// Update is called once per frame
	void Start () {
        heroAnimator = hero.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    public void removeEnemyLife(int value)
    {
        Debug.Log(enemyLife);
        enemyLife = enemyLife - value;

        if(enemyLife <= 0)
        {
            enemyAnimator.SetBool("enemyDied", true);
        }
    }

    public void removeHeroLife(int value)
    {
        heroLife = heroLife - value;

        if (heroLife <= 0)
        {
            heroAnimator.SetBool("Died", true);
            enemyAnimator.SetBool("win", true);
        }
    }
}
