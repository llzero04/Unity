using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    //System.Serializable is used so that a custom class i.e. Sound to appear in the inspecter
    public string name;
    public AudioClip clip;

    // We use the range so that a slider appears on the inspecter
    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;

    [HideInInspector]
    public AudioSource source;
}
