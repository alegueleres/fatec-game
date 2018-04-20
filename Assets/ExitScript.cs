using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SandWall" || other.tag == "Fence")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Hero" && SceneManager.GetActiveScene().name == "Maze1")
        {
            Pause.DoPause();
            GameObject.Find("UI").GetComponent<StartOptions>().ChangeScene(2);
        }

        if (other.tag == "Hero" && SceneManager.GetActiveScene().name == "Maze2")
        {
            Pause.DoPause();
            GameLevelManager.setGameOver(true);
        }
    }
}
