using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public Slider slider;

    void Start()
    {
        var music = GetComponent<AudioSource>();
        var slider = GetComponent<Slider>();
    }
    
    public void Update()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void OnSliderValueChanged()
    {
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
        PlayerPrefs.Save();
    }
}
