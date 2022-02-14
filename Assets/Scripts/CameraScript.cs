using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    
    void Start()
    {
        target = GameObject.Find("Player");
        offset = transform.position;
    }

    
    void Update()
    {

    }

    private void LateUpdate()
    {
        FollowTarget();
    }
    // follow given target
    public void FollowTarget()
    {
        if (target != null)
        {
            transform.position = target.transform.position + offset;
        }
        else
        {
            transform.position = offset;
        }

    }
}
