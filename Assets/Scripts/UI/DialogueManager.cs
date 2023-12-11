using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject currentAnimal;
    public GameObject dialogueUI;
    private bool viewDialogue;
    private float timerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        viewDialogue = false;
        timerDialogue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (viewDialogue)
        {
            timerDialogue += Time.deltaTime;
            if (timerDialogue >= 5.0f)
            {
                viewDialogue = false;
                dialogueUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (viewDialogue == false)
        {
            // Check if the colliding object is the player
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                viewDialogue = true;
                dialogueUI.SetActive(true);
            }
            
        }
    }
}
