using UnityEngine;

public class camera_cinematics : MonoBehaviour
{
    public Transform target; // The target to follow (the player in this case)
    public Vector3 offset = new Vector3(0f, 3f, -7f); // Offset from the target
    public float moveSpeed = 5f; // Speed of camera movement
    public float rotationSpeed = 5f; // Speed of camera rotation
    int i = 0;
    void Update()
    {
        // transform.position = new Vector3(0, 3, transform.position.z);
        if (GameManager.startgame == true && i==0)
        {
             cine();

        }
    }
 
    void cine()
    {
        // Calculate the target position with an offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Look at the target
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        Invoke(nameof(setfix), 1f);

       
    }
    private void setfix()
    {
        transform.position = offset;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        i++;
    }
}
