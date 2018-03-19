using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatScript : MonoBehaviour {

    private Animator heroAnimator;

    private Animator enemyAnimator;

    public GameObject hero;

    public GameObject enemy;

    public Sprite[] heroLifeSprites;

    public Image heartUI;

    private int heroLife = 5;

    public int enemyLife = 20;

    private bool attack;
	
	// Update is called once per frame
	void Start () {
        heroAnimator = hero.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    public void removeEnemyLife(int value)
    {
        GameLevelManager.addScore(5);
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
        GameLevelManager.removeScore(10);
        heroLife = heroLife - value;
        heartUI.sprite = heroLifeSprites[heroLife];

        if (heroLife <= 0)
        {
            heroAnimator.SetBool("Died", true);
            enemyAnimator.SetBool("win", true);
            GameLevelManager.setGameOver(true);
        }
        else
        {
            heroAnimator.SetTrigger(Animator.StringToHash("Hurt"));
        }
    }
}
