using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameAudioMixer : MonoBehaviour
{

    [SerializeField] private string VolumeParameter = "Master";
    [SerializeField] private AudioMixer Mixer;
    //[SerializeField] private Slider VolumeSlider;
    [SerializeField] private float VolumeMult = 20f;

    private void Awake()
    {
        Mixer.GetFloat(VolumeParameter, out float currentVolume);
        //VolumeSlider.SetValueWithoutNotify(Mathf.Pow(10, currentVolume / VolumeMult));
        //VolumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        Mixer.SetFloat(VolumeParameter, Mathf.Log10(value) * VolumeMult);
    }

    private void OnDestroy()
    {
        //VolumeSlider.onValueChanged.RemoveListener(HandleSliderValueChanged);
    }

}
