using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x != 0.0 && transform.localScale.x != 0.0 && transform.localScale.x != 0.0)
        {
            transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
        }
        
    }

    void Awake()
    {
        Destroy(gameObject, 5.0f);
    }
}
