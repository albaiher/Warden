using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{

    [SerializeField] List<GameObject> animalForms;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float RunSpeed = 12f;
    private float actualSpeed = 5f;

    [SerializeField] private float turnSpeed = 100f;
    private GameObject currentAnimal;
    private float horizontalInput;
    private float verticalInput;
    
    private CharacterController characterController;

    private float doubleTapTime = 0.1f; // Tiempo en segundos para considerar un doble toque
    private float lastVerticalInputTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        

        if ( Input.GetButtonDown("Vertical") && (Time.time - lastVerticalInputTime <= doubleTapTime))
        {
            actualSpeed = RunSpeed;
        }
        else if (verticalInput <= 0)
        {
            actualSpeed = speed;
        }

        if (Input.GetButtonUp("Vertical") && verticalInput >= 0)
        {
            lastVerticalInputTime = Time.time;
        }


        Vector3 move = characterController.transform.forward * verticalInput;
        move.y += -9.86f * Time.time;
        characterController.Move(move * Time.deltaTime * actualSpeed);
        characterController.transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

    }


}
