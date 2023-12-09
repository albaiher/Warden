using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Vector3 respawn;


    private void Start()
    {
        respawn = this.gameObject.transform.position;
    }
    public void SetLastCheckPoint(Vector3 position)
    {
        respawn = position;   
    }

    public void Respawn() 
    {
        this.gameObject.transform.position = respawn;
    }
}
