using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Item item;
    public void OnDrop()
    {
        if (PackageManager.instance == null)
        {
            PackageManager.instance = GamingController.ins.packageManager;
        }
        PackageManager.instance.AddItem(item);
        Destroy(gameObject);
    }
}
