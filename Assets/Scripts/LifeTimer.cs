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

  void LateUpdate () {
    lifeTime -= Time.deltaTime;
    if (lifeTime <= 0) {
      UIManager.SetGameOverMenu(true);
    }
    if (lifeTime >= maxLifeTime) {
      lifeTime = maxLifeTime;
    }
    slider.value = lifeTime;
    timerText.text = lifeTime.ToString("F0");
  }
}
