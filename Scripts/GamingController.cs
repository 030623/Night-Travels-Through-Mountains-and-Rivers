using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamingController : MonoBehaviour
{
    public static GamingController ins;
    public UnityEvent OnInitializeDo;
    #region GameUI
    public Button renWuButton,saveButton,settingBut;
    public Text renWutext, renWuTiptext;
    public GameObject missionTextGroup;

    #endregion
    #region GamingData
    public List<Mission> missionList = new List<Mission>();
    public Mission noneMission;
    GameObject game;
    public PackageManager packageManager;

    public int currentMissionIndex = 0;
    public void SetMission(int index = 0)
    {
        currentMissionIndex = index;
        if (index >= missionList.Count)
        {
            currentMissionIndex = missionList.Count;
            SetNoneMission();
            return;
        }
        else
        {
            if (missionList[currentMissionIndex].isFinished)
            {
                SetMission(currentMissionIndex + 1);
            }
            renWutext.text = missionList[currentMissionIndex].missionName;
            renWuTiptext.text = missionList[currentMissionIndex].missionDescription;
            OnMissionStart();
        }
    }
    public void SetNoneMission()
    {
        renWutext.text = noneMission.missionName;
        renWuTiptext.text = noneMission.missionDescription;
        missionTextGroup.SetActive(false);
    }
    public void OnMissionStart()
    {
        missionList[currentMissionIndex].missionStartEvent.Invoke();
        if (missionList[currentMissionIndex].targetButton!= null)
        {
            missionList[currentMissionIndex].ListenToButton();
        }
    }
    public void OnMissionFinihsed()
    {
        if (currentMissionIndex >= missionList.Count)
        {
            SetNoneMission();
            game.SetActive(false);
            return;
        }
        else
        {
            bool isShow = missionList[currentMissionIndex].isShowMissionText;
            missionList[currentMissionIndex].missionFinishEvent.Invoke();
            SetMission(currentMissionIndex + 1);
            if (!isShow)
            {
                missionTextGroup.SetActive(false);
            }
        }
    }
    public void FinishTartgetMission(string tarName)
    {
        foreach (Mission mission in missionList)
        {
            if (mission.missionName == tarName)
            {
                mission.isFinished = true;
                OnMissionFinihsed();
            }
        }
    }


    #endregion
    private void OnEnable()
    {
        ins = this;
    }
    private void Start()
    {
        OnInitializeDo.Invoke();
    }
}
