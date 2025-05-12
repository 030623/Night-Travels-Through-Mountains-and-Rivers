using UnityEngine;

public class tizi : MonoBehaviour
{
    public float climbSpeed = 2f; 
    private bool isClimbing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnLadder())
        {
            StartClimbing();
        }
        else if (Input.GetKeyUp(KeyCode.Space) || !IsOnLadder())
        {
            StopClimbing();
        }

        if (isClimbing)
        {
            ClimbLadder();
        }
 
    }

    private bool IsOnLadder()
    {
          
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.2f);   
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Ladder"))  
            {
                return true;
            }
        }
        return false;
    }

    private void StartClimbing()
    {
        isClimbing = true;
        
    }

    private void ClimbLadder()
    {
        
        Vector3 movement = Vector3.up * climbSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        
    }

    private void StopClimbing()
    {
        isClimbing = false;

    }

}