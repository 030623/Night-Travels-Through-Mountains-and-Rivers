using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    //[Range(0, 10f)]
    //public float moveSpeed;

    private void OnEnable()
    {
        instance = this;
    }
    public Rigidbody P_controller;
    public Transform N_camera;
    public float P_speed = 6f;//��ɫ�ƶ��ٶ�
    public float N_trunSnoothTime = 0.1f;//��ɫת����ʱ��
    float N_trunSmoothVelocity;
    private void Update()
    {
        float N_horizontal = Input.GetAxisRaw("Horizontal");
        float N_vertical = Input.GetAxisRaw("Vertical");

        Vector3 P_direction = new Vector3(N_horizontal, 0, N_vertical).normalized;

        if (P_direction.magnitude >= 0.1f)
        {
            float N_targetAngle = Mathf.Atan2(P_direction.x, P_direction.z) * Mathf.Rad2Deg + N_camera.eulerAngles.y;
            float N_angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, N_targetAngle, ref N_trunSmoothVelocity, N_trunSnoothTime);
            transform.rotation = Quaternion.Euler(0f, N_angle, 0f);

            Vector3 N_moveDir = Quaternion.Euler(0f, N_targetAngle, 0f) * Vector3.forward;
            //P_controller.MovePosition();
            transform.Translate(N_moveDir.normalized * P_speed * Time.deltaTime);
        }
    }
   /* private void FixedUpdate()
    {
        *//*Vector2 moveDir = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        FreeLook(moveDir);*//*

        // �����������������Ҫ����ķ���
        *//*if (moveDir.y > 0)
        {
            transform.Translate(moveDir.magnitude * moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-moveDir.magnitude * moveSpeed * Time.deltaTime, 0, 0);
        }*//*

        float horizontal = Input.GetAxis("Horizontal"); // ��ȡˮƽ���������
        float vertical = Input.GetAxis("Vertical"); // ��ȡ��ֱ���������

        // �����������������Ҫ����ķ���
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction != Vector3.zero)
        {
            // ���ݷ�������������ҵĳ���
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(direction), moveSpeed * Time.deltaTime);
        }

        // ���ݳ�������������ƶ�����
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;

        // ʹ��Rigidbody��MovePosition�������ƶ����
        Vector3 newPosition = rb.position + movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }*/
    void FreeLook(Vector2 moveDir)
    {
        if (moveDir.sqrMagnitude == 0)
            return;
        //��������ʱ���������ֵ���й�һ�������õ����������Կ�����Ҫ�ƶ��ķ���
        Vector3 dir = moveDir.normalized;
        //Atan2�������Եõ����뷽��Ļ��ȣ�Ȼ�����Mathf.Rad2Deg�ӻ���ת���ɽǶ�
        //����ĽǶ��ټ������Ŀǰ�ĽǶȾ��ܵõ����ս�ɫӦ�ó���ĽǶ�
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //��Ŀ�곯�����ά����ת��Ϊ��Ԫ��
        Quaternion targetDir = Quaternion.Euler(0, angle, 0);
        //��ɫ���򻺶���Ŀ�곯��
        transform.rotation = Quaternion.Lerp(transform.rotation, targetDir, 12 * Time.deltaTime);


    }

    public void Teleport(Transform target)
    {
        transform.position = target.position;
    }


}
