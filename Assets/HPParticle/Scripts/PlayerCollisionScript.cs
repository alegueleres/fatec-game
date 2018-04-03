// This Script changes the player's HP when the player get's hit by a projectile

using UnityEngine;
using System.Collections;

public class PlayerCollisionScript : MonoBehaviour {


	public enum EnumChangeHPType{ Normal = 0, CustomColor = 1, CustomForce = 2, CustomColorandForce = 3, CustomText = 4};
	public EnumChangeHPType ChangeHPType = EnumChangeHPType.Normal;

	public Color CustomColor;
	public Vector3 CustomForce;
	public float CustomForceScatter;

    private bool trigger = false;

    private Collider colliderxD;
    void OnTriggerEnter(Collider col) 
	{
        colliderxD = col;
        /*

            //if the gameobject that hits the character is a projectile
            if (col.gameObject.tag == "Sword" && !trigger && HeroMovements.verifyIfAttack())
            {
                if (ChangeHPType == EnumChangeHPType.Normal)
                {
                    gameObject.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, col.ClosestPointOnBounds(transform.position));
                }
                else if (ChangeHPType == EnumChangeHPType.CustomColor)
                {
                    gameObject.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, col.ClosestPointOnBounds(transform.position), CustomColor);
                }
                else if (ChangeHPType == EnumChangeHPType.CustomForce)
                {
                    gameObject.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, col.ClosestPointOnBounds(transform.position), CustomForce,CustomForceScatter);
                }
                else if (ChangeHPType == EnumChangeHPType.CustomColorandForce)
                {
                    gameObject.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, col.ClosestPointOnBounds(transform.position), CustomForce,CustomForceScatter,CustomColor);
                }
                else if (ChangeHPType == EnumChangeHPType.CustomText)
                {
                    gameObject.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, colliderxD.ClosestPointOnBounds(transform.position), "-" + SwordScript.getDamage().ToString());
                }
                trigger = true;
                Invoke("resetTrigger", 1.5f);
            }

            // I should note that these functions can be called from anyother script as well
            // for example in the ProjectileScript.cs these functions can be called within the OnCollisionEnter function
        */

    }

    private void resetTrigger()
    {
        trigger = false;
    }

    public static void updateEnemyHP(GameObject enemy, Vector3 transformPosition)
    {
        enemy.GetComponent<HPScript>().ChangeHP(SwordScript.getDamage() * -1, enemy.GetComponent<Collider>().ClosestPointOnBounds(transformPosition), "-" + SwordScript.getDamage().ToString());
    }

}
