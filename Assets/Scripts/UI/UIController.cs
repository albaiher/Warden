using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private const int RightClick = 1;

    [SerializeField] private AnimalRingMenu ringMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void initializeUI()
    {
        ringMenu = GetComponentInChildren<AnimalRingMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(RightClick)) 
        {
            ringMenu.gameObject.SetActive(!ringMenu.gameObject.activeSelf);
        }
    }
}
