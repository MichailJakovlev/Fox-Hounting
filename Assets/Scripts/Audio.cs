using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource music;

    public void Start()
    {
        var music = GetComponent<AudioSource>();
       
    }

    public void Update()
    {
         music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
