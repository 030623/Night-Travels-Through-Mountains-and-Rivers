using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Net.NetworkInformation;

public class PingTuManager : MonoBehaviour
{
    public static PingTuManager instance;

    public List<PingTuGrid> pingTuGrids = new List<PingTuGrid>();

    public List<int> correctOrder = new List<int>();

    public List<Transform> winPos = new List<Transform>();
    int movedCount = 0;

    public Text tipText;

    public UnityEvent OnWin;
    public UnityEvent OnLose;

    [HideInInspector] public bool isFinished;

    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        isFinished = false;
        RandomPutPingTu();
    }

    public PingTuGrid currentGrid;

    public void RandomPutPingTu()
    {
        System.Random random = new System.Random();

        for (int i = 0; i < 9; i++)
        {
            //randomArray[i] =  // 生成一个0到8之间的随机整数
            int randomIndex = random.Next(0, 9);
            if (randomIndex == i)
            {
                continue;
            }
            else
            {
                ChangePingTuPosition(pingTuGrids[i], pingTuGrids[randomIndex]);
            }
        }
    }


    public void RemovePingTu()
    {
        currentGrid = null;
    }
    public void SelectPingTu(PingTuGrid pingTu)
    {
        if (currentGrid == null)
        {
            currentGrid = pingTu;
        }
        else
        {
            ChangePingTuPosition(pingTu);
        }
    }
    public void ChangePingTuPosition(PingTuGrid pingTu)
    {
        Vector3 tempPos = currentGrid.transform.position;

        currentGrid.transform.position = pingTu.transform.position;

        pingTu.transform.position = tempPos;

        PingTuGrid temp = currentGrid;

        int temp1 = pingTuGrids.IndexOf(currentGrid);
        int temp2 = pingTuGrids.IndexOf(pingTu);

        pingTuGrids[temp1]  = pingTu;
        pingTuGrids[temp2] = temp;


        currentGrid.CencleSelect();
        currentGrid = null;
    }

    public void ChangePingTuPosition(PingTuGrid p1,PingTuGrid p2)
    {
        Vector3 tempPos = p1.transform.position;

        p1.transform.position = p2.transform.position;

        p2.transform.position = tempPos;

        PingTuGrid temp = p1;

        int temp1 = pingTuGrids.IndexOf(p1);
        int temp2 = pingTuGrids.IndexOf(p2);

        pingTuGrids[temp1] = p2;
        pingTuGrids[temp2] = temp;
    }

    public void CheckCorrectOrder()
    {

        if (isFinished )
        {
            return;
        }
        for (int i = 0; i < pingTuGrids.Count; i++)
        {
            if (pingTuGrids[i].index!= correctOrder[i])
            {
                Lose();
                isFinished = true;
                OnLose.Invoke();
                return;
            }
        }
        isFinished = true;
        Debug.Log("You Win!");
        tipText.text = "恭喜你完成了挑战！";
        WinAnimation();
        //OnWin.Invoke();
    }
    public void Lose()
    {
        tipText.text = "激活失败，你迷失了!";
    }
    public void TryAgain()
    {
        tipText.text = "";
        RandomPutPingTu();
        if(currentGrid!= null) currentGrid.CencleSelect();
        currentGrid = null;
        isFinished = false;
    }
    public void WinAnimation()
    {
        for (int i = 0; i < pingTuGrids.Count; i++)
        {
            pingTuGrids[i].MoveToTarget(winPos[i]);
        }
    }

    public void AddMovedCount()
    {
        movedCount++;
        if (movedCount == 9)
        {
            OnWin.Invoke();
        }
    }
}
