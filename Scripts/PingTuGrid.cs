using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PingTuGrid : MonoBehaviour
{
    public UnityEvent onMouseClick;
    public Outline outLine;
    public bool isSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            if (_isSelected)
            {
                if (PingTuManager.instance.currentGrid==null)
                {
                    outLine.enabled = true;
                    PingTuManager.instance.tipText.text = decoration;
                    PingTuManager.instance.SelectPingTu(this);
                }
                else
                {
                    PingTuManager.instance.tipText.text = "";
                    PingTuManager.instance.ChangePingTuPosition(this);
                }
            }
            else
            {
                outLine.enabled = false;
                PingTuManager.instance.tipText.text = "";
                if (PingTuManager.instance.currentGrid == this)
                {
                    PingTuManager.instance.RemovePingTu();
                }
            }
        }
    }
    bool _isSelected;
    public Button button;
    public string decoration;
    public int index;
    private void Start()
    {
        button.onClick.AddListener(MouseDown);
    }
    public void MouseDown()
    {
        if (PingTuManager.instance.isFinished)
        {
            return;
        }
        onMouseClick.Invoke();

        isSelected = !isSelected;
    }
    public void CencleSelect()
    {
        isSelected = false;
    }

    public void MoveToTarget(Transform target)
    {
        StartCoroutine(MoveToTargetCoroutine(target));
    }

    IEnumerator MoveToTargetCoroutine(Transform target)
    {
        float speed = Vector3.Distance(transform.position, target.position);
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target.position;

        PingTuManager.instance.AddMovedCount();
    }

    
}
