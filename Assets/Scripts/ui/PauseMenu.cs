using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject GameOverMenuUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && GameOverMenuUI.activeSelf == false) {
            if (IsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        IsPaused = false;
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        IsPaused = true;
    }
}
