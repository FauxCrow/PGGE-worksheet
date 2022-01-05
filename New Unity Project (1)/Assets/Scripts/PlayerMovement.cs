using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    CharacterController playerController;

    private Vector3 moveDirection;
    private float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection *= moveSpeed;

        playerController.Move(moveDirection * Time.deltaTime);

        animator.SetFloat("PosX", Input.GetAxis("Horizontal"));
        animator.SetFloat("PosZ", Input.GetAxis("Vertical") * moveSpeed / 2);

        //transform.Rotate(0.0f, Input.GetAxis("Horizontal") * 50f * Time.deltaTime, 0.0f);

        // Sprint key
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 1f;
        }
    }
}
