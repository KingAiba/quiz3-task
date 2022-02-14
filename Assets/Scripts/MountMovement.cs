using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MountState {UnMounted, Mounted}

public class MountMovement : MonoBehaviour
{
    public movementScript myMovementScript;

    //public bool isMounted = false;
    public MountState mountState = MountState.UnMounted;
    public PlayerScript mountedPlayer = null;
    public Transform mountPoint;

    public float[] mountSpeeds;

    void Start()
    {
        myMovementScript = GetComponent<movementScript>();    
    }

    
    void Update()
    {
        MountUpdate();
    }

    private void FixedUpdate()
    {
        //myMovementScript.rotateObject();
        MoveMount();
    }

/*    public bool CheckIfMounted()
    {
        return isMounted;
    }*/

    public void Mount(GameObject obj)
    {
        //isMounted = true;
        //mountState = MountState.Mounted;
        ChangeMountState(MountState.Mounted);
        mountedPlayer = obj.GetComponent<PlayerScript>();

        mountedPlayer.MountingProcedure(this);

        obj.transform.position = mountPoint.transform.position + new Vector3(0, obj.transform.localScale.y/2, 0);
    }

    public void MoveMount()
    {
        if(mountState == MountState.Mounted)
        {
            myMovementScript.rotateObject(mountedPlayer.GetInputVector());
        }
        
        myMovementScript.moveObject(gameObject.transform);
    }

    public void MountUpdate()
    {
        if(mountState == MountState.Mounted)
        {
            mountedPlayer.transform.position = mountPoint.transform.position + new Vector3(0, mountedPlayer.transform.localScale.y / 2, 0);
        }
        else
        {

        }
    }

    public void UnMount()
    {
        if(mountState == MountState.Mounted)
        {
            //Debug.Log("HERE");
            //isMounted = false;
            //mountState = MountState.UnMounted;
            ChangeMountState(MountState.UnMounted);
            mountedPlayer = null;
        }
    }

    public Rigidbody GetMountRigidbody()
    {
        return myMovementScript.GetRigidbody();
    }

    public void ChangeMountState(MountState state)
    {
        mountState = state;
        myMovementScript.SetSpeed(mountSpeeds[(int)state]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            mountedPlayer.UnMountingProcedure();
            mountedPlayer.JumpedProcedure();
            UnMount();
            Destroy(gameObject);
        }
    }
}
