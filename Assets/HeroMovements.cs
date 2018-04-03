using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

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
            if (CrossPlatformInputManager.GetAxis("Vertical") > 0 && !verifyIfAttack() && !verifyIfBlocking())
            {
                animator.SetBool("Run", true);
                moveVertical(CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * runSpeed);
            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (CrossPlatformInputManager.GetAxis("Vertical") < 0 && !verifyIfAttack() && !verifyIfBlocking())
            {
                animator.SetBool("Back", true);
                moveVertical(CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * backSpeed);
            }
            else
            {
                animator.SetBool("Back", false);
            }

            if (CrossPlatformInputManager.GetButton("Attack"))
            {
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Attack", false);
            }

            if (CrossPlatformInputManager.GetButton("Block") )
            {
                animator.SetBool("Block", true);
            }
            else
            {
                animator.SetBool("Block", false);
            }

            if (!verifyIfAttack() && !verifyIfBlocking())
            {
                moveHorizontal(CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * turnSpeed);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            animator.SetTrigger("Win");
            Invoke("restartLevel", 2);
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

    public static bool verifyIfBlocking()
    {
        return animator.GetBool("Block");
    }

    public static bool verifyIfDied()
    {
        return animator.GetBool("Died");
    }

    private void restartLevel()
    {
        SceneManager.LoadScene("Maze1");
    }
}
