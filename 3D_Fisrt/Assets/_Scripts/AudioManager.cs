using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public Slider musicBar, sfxBar;
 
    private void OnEnable()
    {
        float musicVolume = PlayerPrefs.GetFloat("Music_Volume", 0.5f);
        float sfxVolume = PlayerPrefs.GetFloat("SFX_Volume", 1);
        musicBar.value = musicVolume;
        sfxBar.value = sfxVolume;
        PlayMusic(0);
    }

    public void PlayMusic(string name)
    {
        AudioClip audioClip = Array.Find(musicSounds, x => x.name == name);
        if (audioClip == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = audioClip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        AudioClip audioClip = Array.Find(sfxSounds, x => x.name == name);
        if (audioClip == null)
        {
            Debug.Log("AudioSFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(audioClip);
        }
    }
    public void PlayMusic(int index)
    {
        AudioClip audioClip = musicSounds[index];
        if (audioClip == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = audioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(int index)
    {
        AudioClip audioClip = sfxSounds[index];
        if (audioClip == null)
        {
            Debug.Log("AudioSFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(audioClip);
        }
    }
    public void PlayAtPointSFX(int index, Transform transform)
    {
        AudioClip audioClip = sfxSounds[index];
        if (audioClip == null)
        {
            Debug.Log("AudioSFX not found");
        }
        else
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position, sfxSource.volume);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("Music_Volume", volume);
        PlayerPrefs.Save();
        Singleton.Instance.AudioManager.PlaySFX(1);
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFX_Volume", volume);
        PlayerPrefs.Save();
        Singleton.Instance.AudioManager.PlaySFX(1);
    }
}
 