using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject Canvas;
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject GameOverMenuUI;

    public void SetCanvas(bool isActive) {
        Canvas.SetActive(isActive);
    }
    public void SetMainMenu(bool isActive) {
        MainMenuUI.SetActive(isActive);
    }
    public void SetOptionsMenu(bool isActive) {
        OptionsMenuUI.SetActive(isActive);
    }
    public void SetGameOverMenu(bool isActive) {
        GameOverMenuUI.SetActive(isActive);
    }
}
