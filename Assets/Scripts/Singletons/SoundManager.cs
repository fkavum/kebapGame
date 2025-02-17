﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Singletone manager class to handle sounds
public class SoundManager : Singleton<SoundManager>
{
    // array of sound clips for music
    public AudioClip[] musicClips;

    // array of sound clips for winning the game
    public AudioClip[] winClips;

    // array of sound clips for losing the game
    public AudioClip[] loseClips;

    // array of sounds for bonus events (chain reaction clears)
    public AudioClip[] bonusClips;

    // music volume
    [Range(0,1)]
    public float musicVolume = 0.5f;

    // sound effects volume
    [Range(0,1)]
    public float fxVolume = 1.0f;

    // boundaries for random variation in pitch
    public float lowPitch = 0.95f;
    public float highPitch = 1.05f;

    private List<AudioSource> _loopingSounds;
    
	void Start () 
    {
        _loopingSounds = new List<AudioSource>();

	}
	
    // this replaces the native PlayClipAtPoint to play an AudioClip at a world space position
    // this allows a third volume parameter to specify the volume unlike the native version
    // and allows for some random variation so the sound is less monotonous
    public AudioSource PlayClipAtPoint(AudioClip clip, Vector3 position, float volume = 1f,bool  randomizePitch = true,bool loop = false)
    {
        if (clip != null)
        {
            // create a new GameObject at the specified world space position
            GameObject go = new GameObject("SoundFX" + clip.name);
            go.transform.position = position;

            // add an AudioSource component and set the AudioClip
            AudioSource source = go.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = loop;
            if(randomizePitch){
            // change the pitch of the sound within some variation
            float randomPitch = Random.Range(lowPitch, highPitch);
            source.pitch = randomPitch;
            }
            // set the volume
            source.volume = volume;

            // play the sound
            source.Play();

            if (loop)
            {
                _loopingSounds.Add(source);
            }
            else
            {
                // destroy the AudioSource after the clip is done playing
                Destroy(go, clip.length);   
            }

            // return our AudioSource out of the method
            return source;
        }

        return null;
    }

    // play a random sound from an array of sounds
    public AudioSource PlayRandom(AudioClip[] clips, Vector3 position, float volume = 1f,bool  randomizePitch = true,bool loop = false)
    {
        if (clips != null)
        {
            if (clips.Length != 0)
            {
                int randomIndex = Random.Range(0, clips.Length);

                if (clips[randomIndex] != null)
                {
                    AudioSource source = PlayClipAtPoint(clips[randomIndex], position, volume,randomizePitch,loop);
                    return source;
                }
            }
        }
        return null;
    }

    // play a random music clip
    public void PlayRandomMusic()
    {
        PlayRandom(musicClips, Vector3.zero, musicVolume,false,true);
    }

    // play a random win sound
    public void PlayWinSound()
    {
        PlayRandom(winClips, Vector3.zero, fxVolume);
    }

    // play a random lose sound
    public void PlayLoseSound()
    {
        PlayRandom(loseClips, Vector3.zero, fxVolume * 0.5f);
    }

    // play a random bonus sound
    public void PlayBonusSound()
    {
        PlayRandom(bonusClips, Vector3.zero, fxVolume);
    }

    public void StopLoopingSounds()
    {
        foreach (AudioSource loopingSound in _loopingSounds)
        {
            if (loopingSound != null)
            {
                loopingSound.Stop();
                Destroy(loopingSound.gameObject);
            }
        }
    }

    public void NoSoundVolume()
    {
        foreach (AudioSource loopingSound in _loopingSounds)
        {
            if (loopingSound != null)
            {
                loopingSound.volume = 0f;
            }
        }

        musicVolume = 0f;
        fxVolume = 0f;
    }

    public void YesSoundVolume()
    {
        foreach (AudioSource loopingSound in _loopingSounds)
        {
            if (loopingSound != null)
            {
                loopingSound.volume = 1f;
            }
        }
        musicVolume = 1f;
        fxVolume = 1f;
    }
    
}
