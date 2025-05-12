using MEET_AND_TALK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Ye;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public UnityEvent OnInitializeDo;
    public GameObject sceneEndCanvas;
    public GameObject camFollow; // 引用CamFollow脚本

    public bool isWaitingForInput; // 是否处于等待输入状态

    public bool isTalking; // 是否正在对话
    private void OnEnable()
    {
        ins = this;
    }
    private void Start()
    {
        OnInitializeDo.Invoke();

        if (DialogueManager.Instance)
        {
            DialogueManager.Instance.StartDialogueEvent.AddListener(IsDialogeStart);
            DialogueManager.Instance.EndDialogueEvent.AddListener(IsDialogeEnd);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //ToggleMovementAndFollow();
            camFollow.SetActive(!camFollow.activeInHierarchy);
            //PlayerMovement.instance.enabled = isTalking ? false: true;

            if (!isTalking)
            {
                PlayerControl.instance.enabled = camFollow.activeInHierarchy;
            }
        }
    }


    public void IsDialogeStart()
    {
        isTalking = true;
    }
    public void IsDialogeEnd()
    {
        isTalking = false;
    }
    public void LoadTargetScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        //Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void LoadSceneAsync(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsyncRoutine(sceneIndex));
    }
    private IEnumerator LoadSceneAsyncRoutine(int sceneIndex)
    {
        // 异步加载指定的场景索引
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;
        // 异步加载操作未完成时，持续等待
        while (asyncLoad.progress < 0.89f)
        {
            yield return 1;
        }
        asyncLoad.allowSceneActivation = true;
    }

    public void WaitLoadSceneAsync(int sceneIndex)
    {
        StartCoroutine(WaitLoadSceneAsyncRoutine(sceneIndex));
    }

    private IEnumerator WaitLoadSceneAsyncRoutine(int sceneIndex)
    {
        // 异步加载指定的场景索引
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;
        // 异步加载操作未完成时，持续等待
        while (asyncLoad.progress < 0.89f)
        {
            yield return 1;
        }
        // 异步加载完成后，显示场景结束画面
        while (!isWaitingForInput)
        {
            yield return 1;
        }
        asyncLoad.allowSceneActivation = true;
    }

    public void SetisWaitingForInput(bool value)
    {
        isWaitingForInput = value;
    }
}
