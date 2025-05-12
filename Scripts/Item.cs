using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Item
{
    public string itemName; // 物品名称
    public Sprite itemSprite; // 物品图标
    public int itemCount; // 物品数量
    public bool isNoCound; 
    public string itemDescription; // 物品描述
    public UnityEvent OnUse;
    public bool isUsable; // 是否可使用

    // 构造函数，初始化物品的基本信息
    public Item(string name, Sprite sprite, int count = 1, string description = "", UnityEvent onUse = null)
    {
        itemName = name;
        itemSprite = sprite;
        itemCount = count;
        isNoCound = false;
        itemDescription = description;
        OnUse = onUse;

    }
    public void SetCount(int count)
    {
        itemCount = count;
    }
    // 可以添加更多与物品相关的功能，比如使用物品等

}
