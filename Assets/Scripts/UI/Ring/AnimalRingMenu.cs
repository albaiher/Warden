using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRingMenu : MonoBehaviour
{
    [SerializeField] private AnimalShapeRing[] ringShapes;
    [SerializeField] private RingPiece ringPiecePrefab;
    [SerializeField] private AnimalShapeController animalShapeController;

    private RingPiece[] ringPieces;
    private float degreesPerPiece;
    private float gapDegrees = 2f;

    private void Start()
    {
        degreesPerPiece = 360f / ringShapes.Length;

        float distanceToIcon = Vector3.Distance(ringPiecePrefab.icon.transform.position, ringPiecePrefab.background.transform.position);

        ringPieces = new RingPiece[ringShapes.Length];

        for (int i = 0; i < ringShapes.Length; i++) 
        {
            ringPieces[i] = Instantiate(ringPiecePrefab, transform);

            ringPieces[i].background.fillAmount = (1f / ringShapes.Length) - (gapDegrees / 360f);
            ringPieces[i].background.transform.localRotation = Quaternion.Euler(0, 0, degreesPerPiece / 2f + gapDegrees / 2f + i * degreesPerPiece);

            print(ringShapes[i].icon);
            ringPieces[i].icon.sprite = ringShapes[i].icon;

            Vector3 directionVector = Quaternion.AngleAxis(i * degreesPerPiece, Vector3.forward) * Vector3.up;
            Vector3 movementVector = directionVector * distanceToIcon;
            ringPieces[i].icon.transform.localPosition = ringPieces[i].background.transform.localPosition + movementVector;
        }
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            int activeElement = GetActiveElement();
            HighlightActiveElement(activeElement);
            RespondToMouseInput(activeElement);
        }
        
    }

    private int GetActiveElement() 
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
        Vector3 cursorVector = Input.mousePosition - screenCenter;

        float mouseAngle = Vector3.SignedAngle(Vector3.up, cursorVector, Vector3.forward) + degreesPerPiece / 2f;
        float normalizedMouseAngle = NormalizeAngle(mouseAngle);

        return (int)(normalizedMouseAngle / degreesPerPiece);
    }

    private void HighlightActiveElement(int activeElement)
    {
        for (int i = 0; i < ringPieces.Length; i++) 
        { 
            if(i == activeElement)
            {
                ringPieces[i].background.color = new Color(1f, 1f, 1f, 0.75f);
            } 
            else
            {
                ringPieces[i].background.color = new Color(1f, 1f, 1f, 0.5f);
            }
        }
    }

    private void RespondToMouseInput(int activeElement)
    {
        if(Input.GetMouseButtonDown(0))
        {
            animalShapeController.ShiftAnimalTo(ringShapes[activeElement].shape);
            this.gameObject.SetActive(false);
        }
    }

    // Función para normalizar el ángulo
    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
