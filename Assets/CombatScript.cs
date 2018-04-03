using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatScript : MonoBehaviour {

    private Animator heroAnimator;

    private Animator enemyAnimator;

    public GameObject hero;

    public Sprite[] heroLifeSprites;

    public Image heartUI;

    private int heroLife = 5;

    public int enemyLife = 20;

    private bool attack;
	
	// Update is called once per frame
	void Start () {
        heroAnimator = hero.GetComponent<Animator>();
    }

    public void removeEnemyLife(int value, GameObject enemy)
    {
        GameLevelManager.addScore(5);
        EnemyLifeScript enemyLifeScript = (EnemyLifeScript )enemy.GetComponent(typeof(EnemyLifeScript));
        enemyLife = enemyLifeScript.removeCurrentLife(value);
        Debug.Log("enemy life: " + enemyLife);

        if (enemyLife <= 0)
        {
            enemy.GetComponent<Animator>().SetBool("enemyDied", true);
        }
        else
        {
            enemy.GetComponent<Animator>().SetTrigger(Animator.StringToHash("Hurt"));
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
