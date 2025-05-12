using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using MEET_AND_TALK;

public class EndScene : MonoBehaviour
{
    public Image bg;
    [Range(0,2f)]
    public float speed;
    public int targetSceneIndex;
    public bool isNotGo;
    public Color color;

    public UnityEvent OnNormalShowEnd;
    public UnityEvent OnNormalShowImageEnd;
    public UnityEvent OnNormalHideImageEnd;
    private void Start()
    {
        if (!isNotGo)End();
    }
    public void End()
    {
        //GameManager.ins.LoadTargetScene();
        StartCoroutine(nameof(ShowImage));

    }
    IEnumerator ShowImage()
    {
        color.a = 0;
        bg.color = color;
        bg.gameObject.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneIndex);
        asyncLoad.allowSceneActivation = false;
        while (color.a<1)
        {
            color.a += speed * Time.deltaTime;
            bg.color = color;
            yield return 10;
        }
        bg.color = color;
        while (asyncLoad.progress < 0.89f)
        {
            yield return 1;
        }
        asyncLoad.allowSceneActivation = true;
        //GameManager.ins.LoadTargetScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    IEnumerator NormalShowImage()
    {
        color.a = 0;
        bg.color = color;
        bg.gameObject.SetActive(true);
        while (color.a < 1)
        {
            color.a += speed * Time.deltaTime;
            bg.color = color;
            yield return 10;
        }
        bg.color = color;
        print("end");
        OnNormalShowImageEnd.Invoke();
    }

    public void NormalShow()
    {
        StartCoroutine(nameof(NormalShowImage));
    }

    public void NormalHide()
    {
        StartCoroutine(nameof(NormalHideImage));
    }
    IEnumerator NormalHideImage()
    {
        color.a = 1;
        bg.color = color;
        bg.gameObject.SetActive(true);
        while (color.a >0)
        {
            color.a -= speed * Time.deltaTime;
            bg.color = color;
            yield return 10;
        }
        bg.color = color;
        print("end");
        OnNormalHideImageEnd.Invoke();
    }

    public void NormalShow(CanvasGroup group)
    {
        StartCoroutine(nameof(NormalShowAlpha),group);
    }
    IEnumerator NormalShowAlpha(CanvasGroup group)
    {
        group.alpha = 0;
        group.gameObject.SetActive(true);
        while (group.alpha < 1)
        {
            group.alpha += speed * Time.deltaTime;
            yield return 10;
        }
        group.alpha = 1;
        OnNormalShowEnd.Invoke();
    }



}
