using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer AudioMixer;

    [SerializeField] private Slider Slider;
    [SerializeField] private string MasterParameter = "Volume";

    [SerializeField] private float VolumeMulti = 20f;

    private void Awake()
    {
        AudioMixer.GetFloat(MasterParameter, out float currentVolume);
        Slider.SetValueWithoutNotify(Mathf.Pow(10, currentVolume / VolumeMulti));
        Slider.onValueChanged.AddListener(SliderValueChange);
    }

    public void SliderValueChange(float value)
    {
        AudioMixer.SetFloat(MasterParameter, Mathf.Log10(value) * VolumeMulti);
    }

    private void OnDestroy()
    {
        Slider.onValueChanged.RemoveListener(SliderValueChange);
    }
}

