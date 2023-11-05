using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{

    [SerializeField] List<GameObject> animalForms;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float turnSpeed = 100f;
    private GameObject currentAnimal;
    private float horizontalInput;
    private float verticalInput;

    private float gravity = -9.18f;

    private CharacterController characterController;

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
        Vector3 move = characterController.transform.forward * verticalInput;
        move.y += gravity * Time.time;
        characterController.Move(move * Time.deltaTime * speed);
        characterController.transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        
    }
}
