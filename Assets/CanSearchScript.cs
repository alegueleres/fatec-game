using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSearchScript : MonoBehaviour {

    public GameObject enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hero")
        {
            enemy.GetComponent<AIPath>().canMove = true;
            enemy.GetComponent<AIPath>().canSearch = true;
            enemy.GetComponent<Animator>().SetBool("search", true);
        }
    }
}
