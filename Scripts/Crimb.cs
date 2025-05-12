using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crimb : MonoBehaviour
{
    public bool isPlayerTrigger;

    public Transform startTransform,endTransform;
    public float moveSpeed;
    private void Update()
    {
        if (isPlayerTrigger && Input.GetKey(KeyCode.Space))
        {
            PlayerControl.instance.transform.position = Vector3.MoveTowards(PlayerControl.instance.transform.position, endTransform.position, moveSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(endTransform.position, PlayerControl.instance.transform.position) < 0.05f)
        {
            this.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerTrigger = false;
        }
    }
}
