using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Move by Screen Reference System
public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public Transform cam;
    private Rigidbody rb;
    public float moveSpeed = 4;
    public float jumpForce = 200f;
    private int jumpLimit = 2;      //������
    private void OnEnable()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam =   Camera.main.transform;
        //anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        //Jump();
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");


        Vector3 screenRight = cam.right;             //����ĻΪ�ο�ϵ�ƶ�
        Vector3 screenForward = cam.forward;
        screenForward.y = 0;                            //��������ֱ����

        Vector3 sumVector = screenForward * v + screenRight * h;                //ʸ��֮��

        if (!(h == 0 && v == 0))
        {
            transform.rotation = Quaternion.LookRotation(sumVector);
        }
        transform.Translate(sumVector * moveSpeed * Time.deltaTime, Space.World);       //Space.World���Բ�����
    }

    bool IsGrounded()                   // ͨ�����߼���ɫ���ڵ����������(��ɫ�������Ҫ�����ڽŵ״�)
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }
    public void Teleport(Transform target)
    {
        transform.position = target.position;
    }

}