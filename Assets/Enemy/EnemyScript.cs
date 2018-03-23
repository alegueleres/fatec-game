using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private static Animator animator;

    public GameObject enemy;

    void Start()
    {
        animator = enemy.GetComponent<Animator>();
    }

    void Update () {
        if (!animator.GetBool("enemyDied"))
        {
            if (animator.GetBool("enemyDied") || animator.GetBool("win"))
            {
                canMove(false);
            }

            if (animator.GetBool("enemyAttack") || animator.GetBool("Hurt"))
            {
                canMove(false);
            }
            else
            {
                canMove(true);
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Hero")
        {
            animator.SetBool("enemyAttack", true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        animator.SetBool("enemyAttack", false);
    }

    private void canMove(bool moveAndSearch)
    {
        AIPath aipath = enemy.GetComponent<AIPath>();
        aipath.canMove = moveAndSearch;
        aipath.canSearch = moveAndSearch;
    }

    public static bool verifyAttack()
    {
        return animator.GetBool("enemyAttack");
    }

    public static bool verifyDie()
    {
        return animator.GetBool("enemyDied");
    }

}
