using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        yourButton.onClick.AddListener(PauseOnClick);
    }

    void PauseOnClick()
    {
        Pause.PauseOnClick();
    }
}
