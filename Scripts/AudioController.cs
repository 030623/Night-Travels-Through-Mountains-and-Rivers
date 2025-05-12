using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider; // ����UI Slider
    public AudioSource audioSource; // ����AudioSource

    void Start()
    {
        // ȷ�������õ�Slider��AudioSource
        if (volumeSlider != null && audioSource != null)
        {
            // ��ʼ��Slider��ֵΪ��ǰ����
            volumeSlider.value = audioSource.volume;
            // ����¼���������Sliderֵ�仯ʱ����ChangeVolume����
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(volumeSlider.value); });
        }
    }

    // ���������ķ���
    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
