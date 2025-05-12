using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PackageManager : MonoBehaviour
{
    public static PackageManager instance;
    public UnityEvent OnInitialiseDo;
    public UnityEvent OnGridClickDo;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        OnInitialiseDo.Invoke();
    }
    public List<GridItem> listItems = new List<GridItem>(); // 物品网格列表
    public List<GridItem> moveListItems = new List<GridItem>(); // 移动物品网格列表

    public List<Item> items = new List<Item>(); // 物品列表
    public Panitting painting; // 画板

    public void AddItem(Item item)
    {
        foreach (var i in listItems)
        {
            if (i.item == null || i.item.itemName.Length == 0)
            {
                i.SetItem(item);
                return;
            }
            else if (i.item.itemName == item.itemName)
            {
                
                i.item.itemCount += item.itemCount;
                i.isHide = false;
                return;
            }
        }
        Debug.Log("物品网格已满！");
    }
    public void AddItem(string itemName)
    {
        string n = itemName.Split(' ')[0];
        int count;
        int.TryParse(itemName.Split(' ')[1],out count);
        foreach (var i in items)
        {
            if (i.itemName == n)
            {
                int temp = i.itemCount;
                if (count > 0)
                {
                    i.itemCount = count;
                }
                AddItem(i);
                i.itemCount = temp;
                return;
            }
        }
    }

    public void UseItem(string itemName)
    {
        foreach (GridItem i in listItems)
        {
            if (i.item!= null && i.item.itemName == itemName)
            {
                i.UseItem(true);
                return;
            }
        }
    }
    public void GetAndPutItem(string itemName)
    {
        foreach (var i in items)
        {
            if (i.itemName == itemName)
            {
                AddItem(i);
                return;
            }
        }
    }
    public void PutOnPaper(string itemName)
    {
        if (painting.gameObject.activeInHierarchy)
        {
            foreach (var i in painting.printOrderString)
            {
                if (i == itemName)
                {
                    foreach (var j in listItems)
                    {
                        if (j.item.itemName == itemName)
                        {
                            painting.PaintOnPaper(j);
                        }
                    }
                    return;
                }
            }
            
        }
    }
}
