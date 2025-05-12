using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SuiPian : MonoBehaviour
{
    public UnityEvent onSuiPianFull;
    public int targetNum = 0;
    public int num
    {
        get { return _num; }
        set { 
            _num = value; 
            if (_num == targetNum)
            {
                _num = targetNum;
                GetAllSuiPianInScene();
            }
        }
    }
    int _num = 0;
    public void GetAllSuiPianInScene()
    {
        print("SuiPian Full");
        onSuiPianFull.Invoke();
    }
    public void AddSuiPian()
    {
        num++;
    }
}
