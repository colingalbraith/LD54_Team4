using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private NPCDialogue dialoguePanel;
    [SerializeField] private string[] dialogue;
    
    [SerializeField] private float letterSpeed;

    private bool playerIsClose = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePanel.InMiddle)
            {
                dialoguePanel.StartDialogue(dialogue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
