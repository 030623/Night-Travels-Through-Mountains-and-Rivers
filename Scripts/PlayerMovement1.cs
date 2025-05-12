using UnityEngine;


namespace Ye
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 10f;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Vector3 movement = Vector3.zero;

            // º‡Ã˝WASDº¸ ‰»Î  
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                movement += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                movement -= Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                movement -= Vector3.right;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                movement += Vector3.right;
            }


            movement = movement.normalized * moveSpeed * Time.deltaTime;


            if (movement != Vector3.zero)
            {

                rb.MovePosition(rb.position + movement);
            }
        }
    }

}