using UnityEngine;
using UnityEngine.InputSystem;
public class PayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    public float speed = 0; 


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }


    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 


    }
    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rigidBody.AddForce(movement * speed);
   
    }

}
