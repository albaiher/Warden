using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnim : MonoBehaviour
{

    [SerializeField] List<GameObject> animalForms;
    private GameObject currentAnimal;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        currentAnimal = animalForms[0];
        animator = currentAnimal.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isWalkingBack = animator.GetBool("isWalkingBack");
        bool isTurningRight = animator.GetBool("isTurningRight");
        bool isTurningLeft = animator.GetBool("isTurningLeft");

        //walk
        bool pressedW = Input.GetKey("w");
        if (!isWalking && pressedW) {
            animator.SetBool("isWalking", true);
        }
        else if (isWalking && !pressedW) {
            animator.SetBool("isWalking", false);
        }

        //backwards
        bool pressedS = Input.GetKey("s");
        if (!isWalking && pressedS) {
            animator.SetBool("isWalkingBack", true);
        }
        else if (isWalkingBack && !pressedS) {
            animator.SetBool("isWalkingBack", false);
        }

        //turn left
        bool pressedA = Input.GetKey("a");
        if(!isTurningLeft && pressedA && !pressedW && !pressedS){
            animator.SetBool("isTurningLeft", true);
        }
        else if(isTurningLeft && !pressedA){
            animator.SetBool("isTurningLeft", false);
        }

        //turn right
        bool pressedD = Input.GetKey("d");
        if(!isTurningRight && pressedD && !pressedW && !pressedS){
            animator.SetBool("isTurningRight", true);
        }
        else if(isTurningRight && !pressedD){
            animator.SetBool("isTurningRight", false);
        }

    }
}
