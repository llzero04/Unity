using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // gameObject.AddComponent<AudioSource>();
        
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.clip = s.clip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAudio(string name)
    {
        int idx = -1;
        for(int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName.Equals(name) == true)
            {
                idx = i;
                break;
            }
        }

        if (idx == -1)
        {
            Debug.LogWarning("Sound " + name + " not found");
        }
        else
        {
            sounds[idx].source.Play();
        }
    }

    public void stopAudio(string name)
    {
        int idx = -1;
        for(int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].soundName.Equals(name) == true)
            {
                idx = i; break;
            }
        }

        if (idx == -1) Debug.LogWarning("Sound " + name + " not found");
        else sounds[idx].source.Stop();
    }
}
