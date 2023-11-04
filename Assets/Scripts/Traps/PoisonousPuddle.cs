using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousPuddle: MonoBehaviour
{
    private int PoisonTicks;
    private bool Poisoned;
    private PlayerController CurrentPlayer;
    private float Timer;
    private float TriggerInterval;

    // Start is called before the first frame update
    void Start()
    {
        PoisonTicks = 0;
        Poisoned = false;
        TriggerInterval = 4f; // Nos hacemos daño cada 4 seg
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= TriggerInterval)
        { 
            if (Poisoned)
            {
                CurrentPlayer.takeDamage(2);
                PoisonTicks++;
            }

            Timer = 0f;
        }

            if(PoisonTicks == 5)
            {
                Poisoned = false;
                PoisonTicks = 0;
            }

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            CurrentPlayer = player;
            if (Poisoned)
            {
                PoisonTicks = 0;
            }
            else
            {
                Poisoned = true;
                CurrentPlayer.takeDamage(2);
                Timer = 0f;
            }
        }
    }
}
