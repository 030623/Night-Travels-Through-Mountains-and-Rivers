using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[System.Serializable]
public class Mission
{
    public string missionName;
    public string missionDescription;
    public UnityEvent missionStartEvent;
    public UnityEvent missionFinishEvent;
    public Button targetButton;
    public bool isFinished;
    public bool isShowMissionText;
    public void ListenToButton()
    {
        targetButton.onClick.AddListener(TargetButtonClick);
    }
    public void TargetButtonClick()
    {
        missionFinishEvent.Invoke();
        GamingController.ins.OnMissionFinihsed();
        targetButton.onClick.RemoveListener(TargetButtonClick);
    }
}
