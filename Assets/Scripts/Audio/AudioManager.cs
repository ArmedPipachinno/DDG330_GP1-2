using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource MasAudioSauce;
    [SerializeField] private AudioSource SFXAudioSauce;
    [SerializeField] private AudioClip BallBounce;
    [SerializeField] private AudioClip PurchaseItem; 
    [SerializeField] private AudioClip CanNotPurchaseItem;
    [SerializeField] private AudioClip HitHP;

    public void MasterVolumeTest()
    {
        MasAudioSauce.clip = BallBounce;
        MasAudioSauce.Play();
    }

    public void SFXVolumeTest()
    {
        SFXAudioSauce.clip = PurchaseItem;
        SFXAudioSauce.Play();
    }

    public void PlayHitSound()
    {
        SFXAudioSauce.clip = HitHP;
        SFXAudioSauce.Play();
    }
    public void PlayBounceSound()
    {
        SFXAudioSauce.clip = BallBounce;
        SFXAudioSauce.Play();
    }    
    public void PlayPurcaseSound()
    {
        SFXAudioSauce.clip = PurchaseItem;
        SFXAudioSauce.Play();
    }
    public void PlayCanNotPurcaseSound()
    {
        SFXAudioSauce.clip = CanNotPurchaseItem;
        SFXAudioSauce.Play();
    }

}
