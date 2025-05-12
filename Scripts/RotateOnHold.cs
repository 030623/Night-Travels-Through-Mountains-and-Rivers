using UnityEngine;

public class RotateOnHold : MonoBehaviour
{
    public float rotateSpeed = 90f;  
    private bool isRotating = false; 
    void Start()
    {
    }
    void Update()
    {
 
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isRotating = true;
                }
            }
        }

 
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {

            isRotating = false;
        }

        if (isRotating)
        {
            RotateObject();
        }
    }

    private void RotateObject()
    {
  
        transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);

    }
}