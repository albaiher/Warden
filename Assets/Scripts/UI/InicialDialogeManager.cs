using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InicialDialogeManager : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] TextMeshProUGUI dialogTextSubs;
    public GameObject panelUI;
    public GameObject subsUI;
    public GameObject fadelUI;
    private string[] texts = new string[7];
    private SFXManager sfxManager;
    private int i = 0;
    private bool finished = false;
    private bool startSubtitules;
    private float timerSubs;

    // Start is called before the first frame update
    void Start()
    {
        texts[0] = "Qué ha pasado... dónde estoy...";
        texts[1] = "No recuerdo nada de anoche...";
        texts[2] = "Bebí demasiado... \r\nEspero no haber causado más incidentes o Laguna se enfadará...";
        texts[3] = "¡Pero qué ha pasado!";
        texts[4] = "¡Me he convertido en un ciervo!";
        texts[5] = "No puede ser... \r\nTengo que buscar respuestas...";
        texts[6] = "Debo encontrar a Cyxta, el sabrá que me ha pasado...";
        StartCoroutine(TypeDialog(texts[0], dialogText));
        i++;
        sfxManager = SFXManager.Instance;
        sfxManager.PlayAudio(AudioType.ST_MAIN_SOUNDTRACK);
    }

    void Update()
    {
        if (startSubtitules)
        {
            timerSubs += Time.deltaTime;
            if (timerSubs >= 5.0f)
            {
                startSubtitules = false;
                subsUI.SetActive(true);
                StartCoroutine(TypeDialog(texts[i], dialogTextSubs));
                i++;
            }
        }
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
        if (i >= 1 && i < 3 && finished)
        {
            finished = false;
            StartCoroutine(TypeDialog(texts[i], dialogText));
            i++;
        }

        if (i == 3 && finished)
        {
            panelUI.SetActive(false);
            fadelUI.SetActive(true);
            startSubtitules = true;
        }
    }

    public void ShowSubtitules()
    {
        if (i >= 4 && i < 7 && finished)
        {
            finished = false;
            StartCoroutine(TypeDialog(texts[i], dialogTextSubs));
            i++;
        }
        
        if (i == 7 && finished)
        {
            subsUI.SetActive(false);
        }
    }
}
