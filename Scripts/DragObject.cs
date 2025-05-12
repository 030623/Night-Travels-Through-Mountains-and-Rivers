using UnityEngine;

public class DragObject : MonoBehaviour
{
    /*    private Vector3 screenPoint;
        private Vector3 offset;
        private float originalX;

        void OnMouseDown()
        {
            originalX = transform.position.x;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }

        void OnMouseDrag()
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
            transform.position = new Vector3(originalX + (cursorPosition.x - originalX), transform.position.y, transform.position.z);
        }*/


    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 originalPosition;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        originalPosition = gameObject.transform.position;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        // ��ԭʼλ�����϶���Ĳ�ֵ��ӣ���ʵ����x��z���ϵ��ƶ�
        transform.position = new Vector3(originalPosition.x + (cursorPosition.x - originalPosition.x),
                                        transform.position.y,
                                        originalPosition.z + (cursorPosition.z - originalPosition.z));
    }
}
