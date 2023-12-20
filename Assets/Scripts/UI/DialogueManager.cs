using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {                
            viewDialogue = true;
            dialogueUI.SetActive(true);
        }
    }
}
