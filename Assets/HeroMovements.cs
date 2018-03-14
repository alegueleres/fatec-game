using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovements : MonoBehaviour {

    private static Animator animator;

    public float runSpeed = 3.0f;

    public float backSpeed = 2.5f;

    public float turnSpeed = 150.0f;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!animator.GetBool("Died"))
        {
            if (Input.GetAxis("Vertical") > 0 && !verifyIfAttack() && !verifyIfBlocking())
            {
                animator.SetBool("Run", true);
                moveVertical(Input.GetAxis("Vertical") * Time.deltaTime * runSpeed);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (Input.GetAxis("Vertical") < 0 && !verifyIfAttack() && !verifyIfBlocking())
            {
                animator.SetBool("Back", true);
                moveVertical(Input.GetAxis("Vertical") * Time.deltaTime * backSpeed);
            }
            else
            {
                animator.SetBool("Back", false);
            }

            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Attack", false);
            }

            if (Input.GetButton("Fire2"))
            {
                animator.SetBool("Block", true);
            }
            else
            {
                animator.SetBool("Block", false);
            }

            if (!verifyIfAttack() && !verifyIfBlocking())
            {
                moveHorizontal(Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
            }
        }
    }

    private void moveVertical(float speed)
    {
        transform.Translate(0, 0, speed);
    }

    private void moveHorizontal(float speed)
    {
        transform.Rotate(0, speed, 0);
    }

    public static bool verifyIfAttack()
    {
       return animator.GetBool("Attack");
    }

    private bool verifyIfBlocking()
    {
        return animator.GetBool("Block");
    }
}
