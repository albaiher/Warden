using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private const int RightClick = 1;
    private float timeScale = 0f;

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
            if (ringMenu.gameObject.activeSelf)
            {
                timeScale = 1f;
            }
            else {
                timeScale = 0f;
            }

            Time.timeScale = timeScale;

            ringMenu.gameObject.SetActive(!ringMenu.gameObject.activeSelf);
        }
    }
}
