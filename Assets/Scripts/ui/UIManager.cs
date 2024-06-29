using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public GameObject Canvas;
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject GameOverMenuUI;
    public GameObject Panel;
    public GameObject MoblieControl;

    [SerializeField] public TextMeshProUGUI timerTextMenu;

    public void SetCanvas(bool isActive)
    {
        Canvas.SetActive(isActive);
    }
    public void SetMainMenu(bool isActive)
    {
        MainMenuUI.SetActive(isActive);
    }
    public void SetOptionsMenu(bool isActive)
    {
        OptionsMenuUI.SetActive(isActive);
    }
    public void SetGameOverMenu(bool isActive, string score)
    {
        GameOverMenuUI.SetActive(isActive);
        timerTextMenu.text = score;
        Time.timeScale = 0;
        Panel.SetActive(true);
    }
}
