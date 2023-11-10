using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource audioSource;

    public Sound[] sounds;

    void Awake ()
    {
        instance = this;
    }

    public void Play(SoundType soundType)
    {	
        Sound s = Array.Find(sounds, item => item.soundType == soundType);
        audioSource.volume = s.volume;
        audioSource.pitch = s.pitch;
       
        audioSource.PlayOneShot(s.clip);
    }

}

[Serializable]
public class Sound
{
    public SoundType soundType;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume;
    [Range(-3f, 3f)] public float pitch;
}

public enum SoundType
{
    None,
    Shoot,
    Damage,
    PlayerHit
    
}