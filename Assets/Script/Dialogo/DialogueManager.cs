using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum TypeOfDialogue
{
    Tutorial,
    Quest
}
public class DialogueManager : MonoBehaviour
{
   
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    int x = 0;
    bool controle;
    bool terminou;
    string theSentence;
    bool starting;
    public Action OnEndDialogue;
    void Start()
    {
        sentences = new Queue<string>();
        
    }
    private void Update()
    {
        if (starting)
        {
            
            if (Input.GetMouseButtonDown(0) && !controle)
            {
                controle = !controle;
                if (!terminou)
                    StaticText();
                else
                    DisplayNextSentence();


            }
            if (Input.GetMouseButtonDown(0) && controle)
            {
                controle = !controle;
            }
        }
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        terminou = false;
        starting = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        //significa que acabou o dialogo
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        //se ainda tiver alguma sentença que nao foi

            theSentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(theSentence));
        
    }
    void StaticText()
    {
        StopAllCoroutines();
        dialogueText.text = theSentence;
        terminou = true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        // toCharArray converte string em char
        foreach(char letter in sentence.ToCharArray())
        {
            x++;
            dialogueText.text += letter;
            if (x == sentence.ToCharArray().Length)
            {
                terminou = true;
                x = 0;
            }
            else
                terminou = false;
                
            yield return new WaitForSeconds(0.1f);
            
        }
    }
    void EndDialogue()
    {
        starting = false;
        OnEndDialogue?.Invoke();
    }
}
