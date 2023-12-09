using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeTreeFall : MonoBehaviour
{

    Animator animator;
    public GameObject tree;
    private bool fallen;

    // Start is called before the first frame update
    void Start()
    {
        //fallen = false;
        //animator = tree.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        //
    }
}
