using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string soundName;

    [Range(0f, 1f)]
    public float pitch;
    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;
}
