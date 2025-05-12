using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Panitting : MonoBehaviour
{
    public UnityEvent onPaintFinish;
    public List<string> printOrderString = new List<string>();
    public List<GameObject> images = new List<GameObject>();
    public GridItem jiaoDai;

    public Text tipText;
    public int printIndex = 0;
    public void PaintOnPaper(GridItem g)
    {
        if (printOrderString[printIndex] == g.item.itemName)
        {
            g.item.isNoCound = false;
            images[printIndex].SetActive(true);
            printIndex++;
            g.gameObject.SetActive(false);
        }
        else
        {
            g.item.isNoCound = true;
            ShowTip("不是先放这个。");
        }
    }
    public void UseJiaoDai(GridItem item)
    {
        if (printIndex >= printOrderString.Count)
        {
            //使用
            jiaoDai.gameObject.SetActive(false);
            if (item == null)
            {
                print(null);
            }
            item.Show();
            ShowTip("制作完成。");
            foreach (var i in images)
            {
                i.SetActive(false);
            }
            //PackageManager.instance.AddItem("夏天的花 1");
            onPaintFinish.Invoke();
        }
        else
        {
            //item.isNoCound = true;
        }
    }
    public void ShowTip(string tip)
    {
        tipText.text = tip;
        tipText.gameObject.SetActive(true);
        Invoke(nameof(HidTip), 2f);
    }
    public void HidTip()
    {
        tipText.text = "";
        tipText.gameObject.SetActive(false);
    }
}
