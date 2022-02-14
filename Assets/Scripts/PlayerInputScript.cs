using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    public Vector3 InputVector = new Vector3(0, 0, 0);
    //public bool
    void Start()
    {
        
    }

    
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        InputVector = new Vector3(horizontal, 0, 0);
        //Debug.Log(InputVector);
    }

    public Vector3 GetInputVector()
    {
        return InputVector;
    }
}
