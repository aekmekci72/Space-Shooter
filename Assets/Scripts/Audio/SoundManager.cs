using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;

    [SerializeField] private float effectVolume;


    [field: SerializeField] public AudioClip PlayerLaser { get; private set; }
    [field: SerializeField] public AudioClip EnemyLaser { get; private set; }
    [field: SerializeField] public AudioClip EnemyDamage { get; private set; }
    [field: SerializeField] public AudioClip PlayerDamage { get; private set; }
    

    private AudioClip _chosenAudio;

    public void Start ()
    {
        soundEffectSource.volume = effectVolume;
    }


    public void PlayEffect(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

}