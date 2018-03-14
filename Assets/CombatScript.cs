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

    private bool attack;
	
	// Update is called once per frame
	void Start () {
        heroAnimator = hero.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    public void removeEnemyLife(int value)
    {
        enemyLife = enemyLife - value;
        Debug.Log("enemy life: " + enemyLife);

        if (enemyLife <= 0)
        {
            enemyAnimator.SetBool("enemyDied", true);
        }
        else
        {
            enemyAnimator.SetTrigger(Animator.StringToHash("Hurt"));
        }
    }

    public void removeHeroLife(int value)
    {
        heroLife = heroLife - value;
        Debug.Log("hero life: " + heroLife);

        if (heroLife <= 0)
        {
            heroAnimator.SetBool("Died", true);
            enemyAnimator.SetBool("win", true);
        }
        else
        {
            heroAnimator.SetTrigger(Animator.StringToHash("Hurt"));
        }
    }
}
