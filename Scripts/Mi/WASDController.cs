using UnityEngine;

public class WASDController : MonoBehaviour
{
    public float speed = 5f; // 设置移动速度  

    private Vector3 movement; // 存储移动方向的向量  

    void Update()
    {
        // 获取用户的输入  
        float horizontal = Input.GetAxis("Horizontal"); // A和D键  
        float vertical = Input.GetAxis("Vertical"); // W和S键  

        // 计算移动方向  
        movement = new Vector3(horizontal, 0f, vertical);

        // 将移动方向转化为世界空间中的向量（因为默认是局部空间）  
        movement = transform.TransformDirection(movement);

        // 根据时间和速度计算移动距离  
        movement *= speed * Time.deltaTime;

        // 应用移动  
        transform.position += movement;
    }
}