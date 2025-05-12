using UnityEngine;

public class WASDController : MonoBehaviour
{
    public float speed = 5f; // �����ƶ��ٶ�  

    private Vector3 movement; // �洢�ƶ����������  

    void Update()
    {
        // ��ȡ�û�������  
        float horizontal = Input.GetAxis("Horizontal"); // A��D��  
        float vertical = Input.GetAxis("Vertical"); // W��S��  

        // �����ƶ�����  
        movement = new Vector3(horizontal, 0f, vertical);

        // ���ƶ�����ת��Ϊ����ռ��е���������ΪĬ���Ǿֲ��ռ䣩  
        movement = transform.TransformDirection(movement);

        // ����ʱ����ٶȼ����ƶ�����  
        movement *= speed * Time.deltaTime;

        // Ӧ���ƶ�  
        transform.position += movement;
    }
}