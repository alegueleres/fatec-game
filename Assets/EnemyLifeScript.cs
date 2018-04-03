using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeScript : MonoBehaviour {

    public int life = 20;

    private int currentLife;

    private TextMesh hpLife;

	// Use this for initialization
	void Start () {
        currentLife = life;
        hpLife = this.gameObject.transform.Find("HPLife").gameObject.GetComponent<TextMesh>();
    }

    private void Update()
    {
        hpLife.text = currentLife.ToString();
        hpLife.transform.rotation = Camera.main.transform.rotation;
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
