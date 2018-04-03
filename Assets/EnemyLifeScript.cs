using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeScript : MonoBehaviour {

    public int life = 20;

    private int currentLife;

	// Use this for initialization
	void Start () {
        currentLife = life;
	}
	
	public int getCurrentLife()
    {
        return currentLife;
    }

    public int removeCurrentLife(int value)
    {
       return currentLife -= value;
    }
}
