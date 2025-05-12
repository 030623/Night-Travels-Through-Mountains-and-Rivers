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
        // 将原始位置与拖动后的差值相加，以实现在x和z轴上的移动
        transform.position = new Vector3(originalPosition.x + (cursorPosition.x - originalPosition.x),
                                        transform.position.y,
                                        originalPosition.z + (cursorPosition.z - originalPosition.z));
    }
}
