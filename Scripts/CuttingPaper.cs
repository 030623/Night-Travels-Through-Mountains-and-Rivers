using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CuttingPaper : MonoBehaviour
{
    public UnityEvent OnCuttingDo;
    public GameObject tarGameObj;
    public Sprite sprite;
    public Image image;
    public void OnCutting()
    {
        OnCuttingDo.Invoke();
        tarGameObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
