using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Item
{
    public string itemName; // ��Ʒ����
    public Sprite itemSprite; // ��Ʒͼ��
    public int itemCount; // ��Ʒ����
    public bool isNoCound; 
    public string itemDescription; // ��Ʒ����
    public UnityEvent OnUse;
    public bool isUsable; // �Ƿ��ʹ��

    // ���캯������ʼ����Ʒ�Ļ�����Ϣ
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
    // ������Ӹ�������Ʒ��صĹ��ܣ�����ʹ����Ʒ��

}
