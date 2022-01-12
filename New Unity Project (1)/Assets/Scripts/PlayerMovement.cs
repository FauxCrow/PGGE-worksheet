using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public CharacterController mCharacterController;
    public Animator mAnimator;

    public float mWalkSpeed = 1.0f;
    public float mRotationSpeed = 50.0f;

    public float mGravity = -30.0f;
    private Vector3 mVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    
    private float hInput;
    private float vInput;
    private float speed;

    private bool jump = false;
    private bool crouch = false;
    public float mJumpHeight = 1.0f;

    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleInputs();
        Move();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void HandleInputs()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        speed = mWalkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = mWalkSpeed * 2.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jump = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            crouch = !crouch;
            Crouch();
        }
    }

    private void Move()
    {
        if (mAnimator == null) return;

        transform.Rotate(0.0f, hInput * mRotationSpeed * Time.deltaTime, 0.0f);

        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;

        mCharacterController.Move(forward * vInput * speed * Time.deltaTime);
        mAnimator.SetFloat("PosX", 0);
        mAnimator.SetFloat("PosZ", vInput * speed / (2.0f * mWalkSpeed));

        if (jump == true)
        {
            Jump();
            jump = false;
        }
    }

    private void Crouch()
    {
        mAnimator.SetBool("Crouch", crouch);
    }

    private void Jump()
    {
        mAnimator.SetTrigger("Jump");
    }

    void ApplyGravity()
    {
        // apply gravity here
        mVelocity.y += mGravity * Time.deltaTime;

        mCharacterController.Move(mVelocity * Time.deltaTime);
        if (mCharacterController.isGrounded && mVelocity.y < 0)
        {
            mVelocity.y = 0f;
        }
    }
}
