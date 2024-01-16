using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDialogueController : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogText;
    public GameObject panelUI;
    private string[] texts = new string[4];
    private int i = 0;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "Qué ha pasado... el bosque parece muerto...";
        texts[1] = "Sigo sin encontrar a Cyxta...";
        texts[2] = "La última vez que vagué por el Bosque de Jade las cosas estaban más tranquilas...";
        texts[3] = "Me duele demasiado la cabeza... \r\nLo peor de todo es que no parece que Laguna este cerca...";
        StartCoroutine(TypeDialog(texts[0], dialogText));
        i++;
    }

    public IEnumerator TypeDialog(string dialog, TextMeshProUGUI dialogText)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
        finished = true;
    }

    public void ShowDialog()
    {
        if (i >= 1 && i < 4 && finished)
        {
            finished = false;
            StartCoroutine(TypeDialog(texts[i], dialogText));
            i++;
        }

        if (i == 4 && finished)
        {
            SceneManager.LoadScene(3);
        }
    }
}
