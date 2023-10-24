using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalShapeController : MonoBehaviour
{
	private const int RightClick = 1;

	[SerializeField] List<GameObject> animalForms;
    private GameObject currentAnimal;
	private int shapes;
	private int currentShape;
    // Start is called before the first frame update
    void Start()
	{
		initializeShapeShifter();
	}
	// Update is called once per frame
	void Update()
    {
        if (Input.GetMouseButtonDown(RightClick))
		{
			ShiftAnimal();
		}
	}

	private void ShiftAnimal()
	{
		currentAnimal.SetActive(false);
		currentShape = (currentShape + 1) % shapes;
		currentAnimal = animalForms[currentShape];
		currentAnimal.SetActive(true);
	}

	private void initializeShapeShifter()
	{
		currentAnimal = animalForms[0];
		shapes = animalForms.Count;
		currentShape = animalForms.IndexOf(currentAnimal);
		foreach (GameObject ob in animalForms)
		{
			if (!ob.Equals(currentAnimal))
			{
				ob.SetActive(false);
			}
		}
	}


}
