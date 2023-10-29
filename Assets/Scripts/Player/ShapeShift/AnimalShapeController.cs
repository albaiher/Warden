using System;
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
	
	public void ShiftAnimalTo(GameObject shape)
    {
        if (!IsAValidAnimalForm(shape)) return;
        shiftAnimal(shape);
    }

    private bool IsAValidAnimalForm(GameObject shape)
    {
        return FindAnimal(shape) != -1  || currentAnimal.name.Equals(shape.name);
    }

    // Start is called before the first frame update
    void Start()
	{
		initializeShapeShifter();
	}
	// Update is called once per frame
	void Update()
    {

	}

	private void shiftAnimal(GameObject shape)
    {
        int index = FindAnimal(shape);
        currentAnimal.SetActive(false);
        currentShape = index;
        currentAnimal = animalForms[currentShape];
        currentAnimal.SetActive(true);
    }

    private int FindAnimal(GameObject shape)
    {
        int index = -1;

		foreach (GameObject animal in animalForms)
		{
			if (animal.name.Equals(shape.name))
			{
				index = animalForms.IndexOf(animal);
			}
		}

		return index;
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
