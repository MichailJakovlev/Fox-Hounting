using System.Threading;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour {
  public float lifeTime = 100;
  public float maxLifeTime = 100;
  public UIManager UIManager;
  public Slider slider;
  [SerializeField] TextMeshProUGUI timerText;

  bool isTimerRunning = true;

  void LateUpdate () {
    lifeTime -= Time.deltaTime;
    if (lifeTime <= 0 && isTimerRunning) {
      UIManager.SetGameOverMenu(true, timerText.text);
      isTimerRunning = false;
    }
    if (lifeTime >= maxLifeTime) {
      lifeTime = maxLifeTime;
    }
    slider.value = lifeTime;
  }
}
