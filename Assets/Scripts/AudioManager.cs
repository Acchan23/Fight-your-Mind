using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource music, soundEffects;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlayEffect(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }

    public void StopEffect(AudioClip clip)
    {
        soundEffects.clip = clip;
        soundEffects.Stop();
    }
}
