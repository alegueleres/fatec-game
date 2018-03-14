using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldFly : MonoBehaviour {

    public GameObject butterfly;

    public GameObject hero;

    public GameObject exitTarget;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Hero")
        {
            AIPath aipath = butterfly.GetComponent<AIPath>();
            aipath.target = exitTarget.transform;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Hero")
        {
            AIPath aipath = butterfly.GetComponent<AIPath>();
            aipath.target = hero.transform;
        }
    }
}
