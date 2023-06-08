using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public float xRange = 4;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {   //Move player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.W) && isOnGround) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        
        // Keep Player In Bounds
        if (transform.position.x < -xRange) 
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) 
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Light Punch");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Medium Punch");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Heavy Punch");
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Light Kick");
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Medium Kick");
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Heavy Kick");
        }

    }   
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
