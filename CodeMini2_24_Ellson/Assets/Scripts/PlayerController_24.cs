using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_24 : MonoBehaviour
{

    float speed = 10.0f;
    float xLimit = 10.0f;
    float zLimit = 10.0f;
    float jumpForce = 5.0f;
    float gravityModifier = 1.0f;

    bool isGrounded = true;

    Rigidbody playerRb;




    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        else if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);


        }
    }
   



    
    void OnCollisionEnter(Collision collision)
{
    isGrounded = true;
}
void OnCollisionExit(Collision collision)
{
    isGrounded = false;
}
}
