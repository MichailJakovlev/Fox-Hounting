using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject GameOverMenuUI;

    public GameObject Panel;

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
        Time.timeScale = 1;
        Panel.SetActive(false);
    }
    public void Pause() {
        pauseMenuUI.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0;
        Panel.SetActive(true);
    }
}
