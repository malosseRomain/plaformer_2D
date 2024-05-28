using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static AudioManager instance;
    public AudioMixerGroup soundEffectMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de l'AudioManager");
            return ;
        }
        instance = this;
    }

    void Start()
    {
        audioSource.clip = Playlist[0];
        audioSource.Play();
    }

    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % Playlist.Length;
        audioSource.clip =  Playlist[musicIndex];
        audioSource.Play(); 
    }


    public AudioSource PlayClip(AudioClip clip, Vector3 pos)
    {
        GameObject TempGameObject = new GameObject("TempAudio");
        TempGameObject.transform.position = pos;
        AudioSource audioSource = TempGameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(TempGameObject, clip.length);
        return audioSource;
    }
}
