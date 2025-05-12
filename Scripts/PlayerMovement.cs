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
    public float P_speed = 6f;//角色移动速度
    public float N_trunSnoothTime = 0.1f;//角色转身缓冲时间
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

        // 根据输入计算出玩家需要朝向的方向
        *//*if (moveDir.y > 0)
        {
            transform.Translate(moveDir.magnitude * moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-moveDir.magnitude * moveSpeed * Time.deltaTime, 0, 0);
        }*//*

        float horizontal = Input.GetAxis("Horizontal"); // 获取水平方向的输入
        float vertical = Input.GetAxis("Vertical"); // 获取垂直方向的输入

        // 根据输入计算出玩家需要朝向的方向
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction != Vector3.zero)
        {
            // 根据方向向量设置玩家的朝向
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(direction), moveSpeed * Time.deltaTime);
        }

        // 根据朝向和输入计算出移动向量
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;

        // 使用Rigidbody的MovePosition方法来移动玩家
        Vector3 newPosition = rb.position + movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }*/
    void FreeLook(Vector2 moveDir)
    {
        if (moveDir.sqrMagnitude == 0)
            return;
        //将输入检测时保存的输入值进行归一化处理，得到的向量可以看出想要移动的方向
        Vector3 dir = moveDir.normalized;
        //Atan2函数可以得到输入方向的弧度，然后乘于Mathf.Rad2Deg从弧度转换成角度
        //输入的角度再加上相机目前的角度就能得到最终角色应该朝向的角度
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //将目标朝向的三维向量转换为四元数
        Quaternion targetDir = Quaternion.Euler(0, angle, 0);
        //角色朝向缓动至目标朝向
        transform.rotation = Quaternion.Lerp(transform.rotation, targetDir, 12 * Time.deltaTime);


    }

    public void Teleport(Transform target)
    {
        transform.position = target.position;
    }


}
