using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SandWall")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Hero" && SceneManager.GetActiveScene().name == "Maze1")
        {
            GameObject.Find("UI").GetComponent<StartOptions>().ChangeScene(2);
        }
    }
}
