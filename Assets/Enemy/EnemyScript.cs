using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private Animator animator;

    public GameObject enemy;

    void Start()
    {
        animator = enemy.GetComponent<Animator>();
    }

    void Update () {
        if (animator.GetBool("enemyDied"))
        {
            AIPath aipath = enemy.GetComponent<AIPath>();
            aipath.canMove = false;
            aipath.canSearch = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.tag == "Hero");
        if (collider.tag == "Hero")
        {
            animator.SetBool("enemyAttack", true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        animator.SetBool("enemyAttack", false);
    }
}
