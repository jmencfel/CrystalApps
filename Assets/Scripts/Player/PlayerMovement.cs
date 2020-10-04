using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
 
    private bool jumpInput = false;
    private Vector3 movement = Vector2.zero;
    private bool isGrounded = true;


    //animation ids
    private int MoveSpeedHash;
    private int JumpHash;
    private int LandHash;
    private int GroundedHash;
    private void Start()
    {
        CacheAnimationHashes();
    }
    private void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        animator.SetBool(GroundedHash, isGrounded);
        Move();
        Jump();
        Rotate();
    }
    private void CacheAnimationHashes()
    {
        MoveSpeedHash = Animator.StringToHash("MoveSpeed");
        JumpHash = Animator.StringToHash("Jump");
        LandHash = Animator.StringToHash("Land");
        GroundedHash = Animator.StringToHash("Grounded");
    }
     
    private void GetInput()
    {
        movement.x = Input.GetAxis("Horizontal")*movementSpeed;
        movement.z = Input.GetAxis("Vertical")*movementSpeed;
        jumpInput = !jumpInput && Input.GetKey(KeyCode.Space);
    }
    private void Move()
    {      
        rigidBody.velocity = new Vector3(movement.x, rigidBody.velocity.y, movement.z);
        animator.SetFloat(MoveSpeedHash, movement.magnitude);
    }
    private void Jump()
    {
        if (isGrounded && jumpInput)
        {
            isGrounded = false;
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);          
            animator.SetTrigger(JumpHash);
        }
    }
    private void Rotate()
    {
        if(movement!=Vector3.zero)
        transform.rotation = Quaternion.LookRotation(movement);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) >= 0.9)
        {
            isGrounded = true;
            animator.SetTrigger(LandHash);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!isGrounded)
        {
            if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) >= 0.9)
            {
                isGrounded = true;
                animator.SetTrigger(LandHash);
            }
        }
    }


}
