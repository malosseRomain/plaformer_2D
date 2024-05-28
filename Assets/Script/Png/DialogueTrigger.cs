 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private Transform TextToucheUI;

    private void Awake()
    {
        TextToucheUI = gameObject.transform.GetChild(0);
        TextToucheUI.gameObject.SetActive(false);
    }

    private void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            TextToucheUI.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            TriggerDialogue();
    }  

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            TextToucheUI.gameObject.SetActive(false);
            DialogueManager.instance.EndDialogue();
        }
    }
}
