using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnim : MonoBehaviour
{

    [SerializeField] List<GameObject> animalForms;
    private GameObject currentAnimal;
    Animator animator;
    private float horizontalInput;
    private float verticalInput;

    private float doubleTapTime = 0.2f; // Tiempo en segundos para considerar un doble toque
    private float lastVerticalInputTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

        currentAnimal = animalForms[FindAnimal()];
        animator = currentAnimal.GetComponent<Animator>();
    }

    private bool IsCurrentAnimal(GameObject animal)
    {
        return animal.activeSelf;
    }

    private int FindAnimal()
    {
        int index = -1;

        foreach (GameObject animal in animalForms)
        {
            if (IsCurrentAnimal(animal))
            {
                index = animalForms.IndexOf(animal);
            }
        }

        return index;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsCurrentAnimal(currentAnimal))
        {
            currentAnimal = animalForms[FindAnimal()];
            animator = currentAnimal.GetComponent<Animator>();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        bool isWalkingBack = animator.GetBool("isWalkingBack");
        bool isTurningRight = animator.GetBool("isTurningRight");
        bool isTurningLeft = animator.GetBool("isTurningLeft");

        //walk
        if (!isWalking && verticalInput>0) {
            animator.SetBool("isWalking", true);
        }
        else if (isWalking && verticalInput<=0) {
            animator.SetBool("isWalking", false);
        }

        //run
        if (!isRunning && verticalInput >= 0 && Input.GetButtonDown("Vertical") && (Time.time - lastVerticalInputTime <= doubleTapTime))
        {
            animator.SetBool("isRunning", true);
        }
        else if(isRunning && verticalInput <= 0)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }
        if (Input.GetButtonUp("Vertical") && verticalInput >= 0)
        {
            lastVerticalInputTime = Time.time;
            animator.SetBool("isWalking", false);
            isWalking = false;
        }

        //backwards
        if (!isWalking && verticalInput<0) {
            animator.SetBool("isWalkingBack", true);
        }
        else if (isWalkingBack && verticalInput>=0) {
            animator.SetBool("isWalkingBack", false);
        }

        //turn left
        if(!isTurningLeft && horizontalInput<0 && verticalInput == 0)
        {
            animator.SetBool("isTurningLeft", true);
        }
        else if(isTurningLeft && horizontalInput >= 0)
        {
            animator.SetBool("isTurningLeft", false);
        }

        //turn right
        if(!isTurningRight && horizontalInput > 0 && verticalInput == 0)
        {
            animator.SetBool("isTurningRight", true);
        }
        else if(isTurningRight && horizontalInput <= 0)
        {
            animator.SetBool("isTurningRight", false);
        }

    }
}
