using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public void ChangeAudio(Slider slider)
    {
        audioSource.volume = slider.value;
    }
}
