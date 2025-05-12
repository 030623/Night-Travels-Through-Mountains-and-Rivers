using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Slider volumeSlider; // 引用UI Slider
    public AudioSource audioSource; // 引用AudioSource

    void Start()
    {
        // 确保有引用到Slider和AudioSource
        if (volumeSlider != null && audioSource != null)
        {
            // 初始化Slider的值为当前音量
            volumeSlider.value = audioSource.volume;
            // 添加事件监听，当Slider值变化时调用ChangeVolume方法
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(volumeSlider.value); });
        }
    }

    // 调整音量的方法
    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
