using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Diagnostics.SymbolStore;

public class GridItem : MonoBehaviour
{
    public Item item;
    Button button;
    public Image image;
    public Text countText, itemNameText;
    public bool canIneract = true;
    public bool isHide = false;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UseItem);
        if (item!= null && item.itemName.Length>0 && !isHide)
        {
            if (itemNameText != null)
            {
                itemNameText.text = item.itemName;
            }
            image.color = Color.white;
            image.sprite = item.itemSprite;
            if (!item.isNoCound && countText!= null)
            {
                countText.text = item.itemCount.ToString();
            }
        }
        if (isHide && item!= null)
        {
            item.isUsable = false;
        }
    }
    public void SetItem(Item i)
    {
        item = new Item(i.itemName, i.itemSprite, i.itemCount, i.itemDescription, i.OnUse);
        item.isNoCound = i.isNoCound;
        item.isUsable = i.isUsable;
        image.sprite = i.itemSprite;
        image.color = Color.white;
        image.gameObject.SetActive(true);
        if (countText != null)
        {
        countText.text = i.itemCount.ToString();

        }
        if (itemNameText != null)
        {

        itemNameText.text = i.itemName;
        }

    }

    public void UseItem()
    {
        if (item!= null)
        {
            if (canIneract)
            {
                item.OnUse.Invoke();
                if (item==null ||!item.isUsable)
                {
                    return;
                }
                if (!item.isNoCound)
                {
                    if (countText != null)
                    {

                    countText.text = item.itemCount.ToString();
                    }
                    item.itemCount = item.itemCount > 0 ? item.itemCount - 1 : 0;
                    if (item.itemCount == 0)
                    {
                        image.sprite = null;
                        image.color = Color.clear;
                        if(countText != null)
                        {

                        countText.text = "";
                        }
                        if (itemNameText != null)
                        {

                        itemNameText.text = "";
                        }
                        item = null;
                    }
                    else
                    {
                        image.sprite = item.itemSprite;
                        image.color = Color.white;
                    }
                }
            }
        }
    }
    public void UseItem(bool isUse)
    {
        if (item != null)
        {
            item.OnUse.Invoke();
            if (!isUse)
            {
                print(item.itemName + " is not usable");
                return;
            }
            if (!item.isNoCound)
            {
                item.itemCount = item.itemCount > 0 ? item.itemCount - 1 : 0;
                if (countText != null) countText.text = item.itemCount.ToString();
                if (item.itemCount == 0)
                {
                    image.sprite = null;
                    image.color = Color.clear;
                    if (countText != null) countText.text = "";
                    if (itemNameText != null) itemNameText.text = "";
                    item = null;
                }
                else
                {
                    image.sprite = item.itemSprite;
                    image.color = Color.white;
                }
            }
        }
    }
    public void SetCanIneract(bool can)
    {
        canIneract = can;
    }

    public void setHide(bool hide)
    {
        isHide = hide;
        if (isHide)
        {
            item.isUsable = false;
        }
        else
        {
            item.isUsable = true;
            if (!item.isNoCound)
            {
                item.itemCount = item.itemCount > 0 ? item.itemCount - 1 : 0;
                if (countText != null) countText.text = item.itemCount.ToString();
                if (item.itemCount == 0)
                {
                    image.sprite = null;
                    image.color = Color.clear;
                    if (countText != null) countText.text = "";
                    itemNameText.text = "";
                    item = null;
                }
            }
        }
    }
    public void MoveIteTo(GridItem target)
    {
        if (target.item == null || target.item.itemName.Length < 1)
        {
            target.SetItem(item);

        }
        else
        {
            target.item.itemCount += item.itemCount;
        }
        item = null;
        image.sprite = null;
        image.color = Color.clear;
        if (countText != null) countText.text = "";
        itemNameText.text = "";
    }
    public void Hide()
    {
        canIneract = false;
        isHide = true;
        image.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
        if (itemNameText != null) itemNameText.gameObject.SetActive(false);
    }
    public void Hide(bool remove)
    {
        canIneract = false;
        isHide = true;
        image.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
        if (itemNameText != null) itemNameText.gameObject.SetActive(false);
        if (remove)
        {
        item = null;
        }
    }
    public void Show()
    {
        canIneract = true;
        isHide = false;
        if (image != null && item != null)
        {
            image.gameObject.SetActive(true);
            image.sprite = item.itemSprite;
            image.color = Color.white;
            if (!item.isNoCound)
            {
                countText.text = item.itemCount.ToString();
            }
        }

        countText.gameObject.SetActive(true);
        if (itemNameText != null) itemNameText.gameObject.SetActive(true);
    }
}
