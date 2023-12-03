using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource MasAudioSauce;
    [SerializeField] private AudioSource SFXAudioSauce;
    [SerializeField] private AudioClip TestMas;
    [SerializeField] private AudioClip TestSFX;

    public void MasterVolumeTest()
    {
        MasAudioSauce.clip = TestMas;
        MasAudioSauce.Play();
    }

    public void SFXVolumeTest()
    {
        SFXAudioSauce.clip = TestSFX;
        SFXAudioSauce.Play();
    }

}
