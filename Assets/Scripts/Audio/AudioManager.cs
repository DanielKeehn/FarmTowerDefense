using System;
using UnityEngine;
// Import this whenever you are working with sound in Unity
using UnityEngine.Audio;

// Have a list of sound where you can easily add or remove sounds that can be given different properties

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;    
    
    // Awake is called right before Start
    void Awake()
    {

        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop; 
        }
        Play("Temp");
    }

    // Running this function allows the player to play a sound
    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play(); 
    }
}
