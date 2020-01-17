using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import this whenever you are working with sound in Unity
using UnityEngine.Audio;

// Notice this doesn't derive from Monobehavior
// When we makea custom class in Unity and want are attributes to be able to be edited in Unity, we make class serializable

[System.Serializable]

public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
