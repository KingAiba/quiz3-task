using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{ 
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    public float jumpForce = 10f;
    public bool isJumping = false;
    public bool isGrounded = true;

    public Transform jumpTarget;

    private Vector3 input;
    private Rigidbody objectRB;
    private PlayerInputScript inputScript;
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
        inputScript = GetComponent<PlayerInputScript>();
    }

    
    void Update()
    {
        input = inputScript.GetInputVector();       
    }

    private void FixedUpdate()
    {
        rotateObject();
        moveObject();
        Jump();
    }
    // moveobject by applying constant velocity forward
    public void moveObject()
    {
        objectRB.velocity = new Vector3(transform.forward.x*moveSpeed, objectRB.velocity.y, transform.forward.z*moveSpeed);
    }
    // rotate b/w -40 and 40 depending on input
    public void rotateObject()
    {
        if(input.magnitude != 0)
        {
            float horizontal = input.x * 40;

            Quaternion rotation = Quaternion.Slerp(new Quaternion(0, 0, 0, 0), Quaternion.Euler(0, horizontal, 0), Time.deltaTime * rotationSpeed);
            Debug.Log(rotation);
            transform.rotation = rotation;
        }
        
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            objectRB.AddForce((jumpTarget.transform.position - transform.position).normalized * jumpForce, ForceMode.Impulse);
        }
    }
}
