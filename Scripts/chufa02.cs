using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chufa02 : MonoBehaviour
{
    public GameObject tizi;
    public GameObject text03;
    private bool timeGo01;
    public float times;
    public float time01 = 3;
    // Start is called before the first frame update
    void Start()
    {
        text03.SetActive(true);
        tizi.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "player")
        {
            tizi.SetActive(true);
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
                text03.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
