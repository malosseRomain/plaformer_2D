using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text PNGnametext;
    public Text dialogueText;
    private Queue<string> sentences;
    public Animator animator;
    public static DialogueManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Attention plusieur instance de DialogueManager");
            return ;
        }
        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        PNGnametext.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); 
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();//empecher affichage de plusieur phrase si appuy sur suivant avaant la fin de la premiere coroutine
        StartCoroutine(LettreParLettre(sentence));
    }

    IEnumerator LettreParLettre(string sentence)
    {
        dialogueText.text = "";
        foreach (char lettre in sentence.ToCharArray())
        {
            dialogueText.text += lettre;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
