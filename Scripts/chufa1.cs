using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chufa1 : MonoBehaviour
{
    public GameObject qiao;
    public GameObject text01;
    public GameObject text02;
    private bool timeGo01;
    public float times;
    public float time01 = 3;
    private void Start()
    {
        text01.SetActive(true);
        text02.SetActive(false);
        qiao.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "player")
        {
            qiao.SetActive(true);
            text01.SetActive(false);
            text02.SetActive(true);
            timeGo01 = true;
        }

    }
    private void Update()
    {
        if (timeGo01)
        {
            times += Time.deltaTime;
            if (times >= time01)
            {
                text02.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
   
}
