﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Hero")
        {
            Physics.IgnoreCollision(collision.collider, this.GetComponent<CapsuleCollider>());
        }
    }

}
