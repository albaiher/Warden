using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSpikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // The colliding object is the player, call the player's method to subtract life
            player.takeDamage(50);
        }
    }
}
