using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool isJumping = false;
    //public bool isGrounded = true;

    public bool isMounted = false;

    public Rigidbody playerRB;
    public Collider playerCollider;

    private PlayerInputScript inputScript;

    private Vector3 input;

    public MountMovement currMount;

    public Transform jumpTarget;

    public bool isDead = false;
    public int score = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<BoxCollider>();
        inputScript = GetComponent<PlayerInputScript>();
    }


    void Update()
    {
        input = inputScript.GetInputVector();
    }

    private void FixedUpdate()
    {
        TryJump();
    }

    public void MountingProcedure(MountMovement mount)
    {
        score += 25;

        playerCollider.enabled = false;
        playerRB.isKinematic = true;
        playerRB.velocity = Vector3.zero;
        isMounted = true;

        currMount = mount;
    }

    public void UnMountingProcedure()
    {

        currMount.UnMount();

        playerCollider.enabled = true;
        playerRB.isKinematic = false;

        //isMounted = false;


        //currMount = null;
        playerRB.velocity = currMount.GetMountRigidbody().velocity;
    }

    public void JumpedProcedure()
    {
        isMounted = false;
        currMount = null;
    }

    public Vector3 GetInputVector()
    {
        return input;
    }

    public void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && isMounted && !isDead)
        {

            UnMountingProcedure();
            playerRB.AddForce((jumpTarget.transform.position - transform.position).normalized * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    public void ObstacleCollisionProcedure()
    {
        UnMountingProcedure();
        JumpedProcedure();
        isDead = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mount") && !isMounted && collision.gameObject != currMount)
        {
            Debug.Log(collision.gameObject != currMount);
            isJumping = false;
            collision.gameObject.GetComponent<MountMovement>().Mount(gameObject);
        }
    }
}
