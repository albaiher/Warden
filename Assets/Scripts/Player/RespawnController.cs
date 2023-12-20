using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Vector3 respawn = new Vector3(-155.686005f, 0.216999993f, 75.4800034f);

    private static RespawnController instance = null;
    public static RespawnController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (!instance)
        {
            EnsureSingleton();
            DontDestroyOnLoad(this.gameObject);
            RespawnPlayer();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RespawnPlayer();
    }

    public void SetLastCheckPoint(Vector3 position)
    {
        respawn = position;   
    }

    public void setRespawn(Vector3 position) 
    {
        respawn = position;
        Debug.Log(respawn);
    }

    private void RespawnPlayer() 
    {
        Debug.Log(respawn);
        GameObject.FindGameObjectWithTag("Player").transform.position = respawn;
    }

    private void EnsureSingleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
