using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);   
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if (count >= 7) 
            {
                winTextObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Win!";
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));


            }
        }
    }

    void SetCountText() 
    {
        countText.text =  "Score = " + count.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); 
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

}
