using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private bool reached = false;

    private RespawnController respawnController;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        respawnController = RespawnController.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !reached) 
        {
            if (respawnController == null)
            {
                respawnController = RespawnController.Instance;
            }
            respawnController.setRespawn(this.gameObject.transform.position);
            reached = true;
        }
    }
}
