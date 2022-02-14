using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{ 
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;




    //private Vector3 input;
    private Rigidbody objectRB;

    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
        //inputScript = GetComponent<PlayerInputScript>();
    }

    
    void Update()
    {
        //input = inputScript.GetInputVector();       
    }

    private void FixedUpdate()
    {
        //rotateObject();
        //moveObject();
        //Jump();
    }

    // moveobject by applying constant velocity forward
    public void moveObject(Transform directionTransform)
    {
        objectRB.velocity = new Vector3(directionTransform.forward.x*moveSpeed, objectRB.velocity.y, directionTransform.forward.z*moveSpeed);

    }
    // rotate b/w -40 and 40 depending on input
    public void rotateObject(Vector3 input)
    {
        if(input.magnitude != 0)
        {
            float horizontal = input.x * 40;

            Quaternion rotation = Quaternion.Slerp(new Quaternion(0, 0, 0, 0), Quaternion.Euler(0, horizontal, 0), Time.deltaTime * rotationSpeed);
            //Debug.Log(rotation);
            transform.rotation = rotation;
        }
        
    }

    public Rigidbody GetRigidbody()
    {
        return objectRB;
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }


}
