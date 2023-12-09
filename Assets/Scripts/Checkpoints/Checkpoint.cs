using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<PlayerController>().ReachedCheckPoint(this.gameObject.transform.position);
            //animator.SetTrigger("Activate");
        }
    }
}
