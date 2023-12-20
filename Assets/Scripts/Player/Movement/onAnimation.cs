using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onAnimation : MonoBehaviour
{
    private Animator animator;

    private CharacterController characterController;
    private GameObject parent;

    private float jumpSpeed = 5.5f;
    private float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        animator = gameObject.GetComponent<Animator>();
        
        characterController = parent.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.enabled) 
        {
            animator.enabled = true;
        }
        ySpeed += Physics.gravity.y * Time.deltaTime;

        //if (animator && animator.GetBool("useSkill"))
        //{
        //    if (gameObject.name == "Deer Female" && characterController.isGrounded)
        //    {
        //        ySpeed = jumpSpeed;
        //    }
        //}
    }

    public void updateYSpeed()
    {
        ySpeed = jumpSpeed;
    }

    void OnAnimatorMove()
    {
        if (animator)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;

            characterController.Move(velocity);

            transform.parent.rotation = animator.rootRotation;
    
        }
    }
}
