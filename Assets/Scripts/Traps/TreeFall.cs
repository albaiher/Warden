using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{

    Animator animator;
    public GameObject tree;
    private bool fallen;

    // Start is called before the first frame update
    void Start()
    {
        fallen = false;
        animator = tree.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (fallen == false)
        {
            // Check if the colliding object is the player
            PlayerController player = other.GetComponent<PlayerController>();


            if (player != null && animator != null)
            {
                // The colliding object is the player, call the player's method to subtract life
                animator.SetTrigger("isPlayerNear");
            }
            fallen = true;
        }
        
    }
}
