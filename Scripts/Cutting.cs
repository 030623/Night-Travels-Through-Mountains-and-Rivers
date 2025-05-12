using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cutting : MonoBehaviour
{
    public List<CuttingPaper> paters;

    public Sprite[] sprites;

    public List<Transform> imageTransforms;
    public GameObject JianDao;

    public int currentPater = 0;

    public UnityEvent onCutEndDo;

    private void Start()
    {
        while (paters[0].transform.parent.GetChild(0).name == "场景Image")
        {
            RandomPutPaper();
        }
    }

    public void Cut()
    {
        if (currentPater >=0)
        {
            imageTransforms[currentPater].GetComponent<CuttingPaper>().OnCutting();
            currentPater--;
            if(currentPater<0)
            {
                JianDao.SetActive(false);
                onCutEndDo.Invoke();
            }
        }
    }

    public void RandomPutPaper()
    {
        System.Random random = new System.Random();
        //打乱纸张顺序
        for (int i = 0; i < paters.Count; i++)
        {
            int randomIndex = random.Next(0, paters.Count);
            if (randomIndex == i)
            {
                continue;
            }
            else
            {
                //ChangePingTuPosition(pingTuGrids[i], pingTuGrids[randomIndex]);
                Swap(paters[i].transform, paters[randomIndex].transform);
            }
        }
        //Shuffle(paters);
        UpdateTransforms();


    }

    public void UpdateTransforms()
    {
        imageTransforms = new List<Transform>();
        Transform parent = paters[0].transform.parent;
        foreach (var t in parent.GetComponentsInChildren<Transform>())
        {
            if (t != parent)
            {
                imageTransforms.Add(t);
            }
        }
        currentPater = imageTransforms.Count-1;
    }
    public void ChangePaper(CuttingPaper c1, CuttingPaper c2)
    {
        Sprite temp = c1.sprite;

        c1.sprite = c2.sprite;

        c2.sprite = temp;

        GameObject tempObj = c1.tarGameObj;

        c1.tarGameObj = c2.tarGameObj;

        c2.tarGameObj = tempObj;

        UnityEvent tempEvent = c1.OnCuttingDo;

        c1.OnCuttingDo = c2.OnCuttingDo;

        c2.OnCuttingDo = tempEvent;

        c1.image.sprite = c1.sprite;
        c2.image.sprite = c2.sprite;

        Image tempImg = c1.image;

        c1.image = c2.image;

        c2.image = tempImg;

    }

    void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void Swap(Transform firstChild, Transform secondChild)
    {
        if (firstChild != null && secondChild != null && firstChild.parent == secondChild.parent)
        {
            int firstIndex = firstChild.GetSiblingIndex();
            int secondIndex = secondChild.GetSiblingIndex();

            // 交换Sibling Index
            firstChild.SetSiblingIndex(secondIndex);
            secondChild.SetSiblingIndex(firstIndex);
        }
        else
        {
            Debug.LogError("Children must be siblings and not null.");
        }
    }
}
