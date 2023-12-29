using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text contButtonText;
    [SerializeField] private float letterSpeed;

    private string[] dialogue;
    public bool InMiddle { get; private set; }
    private int index = 0;
    private bool finishedTyping;

    public void StartDialogue(string[] dialogue)
    {
        dialogueText.text = "";
        contButtonText.text = "Continue";
        InMiddle = true;

        this.dialogue = dialogue;
        gameObject.SetActive(true);
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        finishedTyping = false;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(letterSpeed);
        }
        finishedTyping = true;
    }

    public void NextLine()
    {
        if (!finishedTyping)
        {
            return;
        }
        if (index < dialogue.Length - 1)
        {
            if (index == dialogue.Length - 2) {
                contButtonText.text = "Exit";
            }
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            dialogueText.text = "";
            index = 0;
            gameObject.SetActive(false);
            InMiddle = false;
        }
    }
}
