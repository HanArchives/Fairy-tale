using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnCollider : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogueTrigger.TriggerDialogue(); // Starts the dialogue
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueManager.EndDialogue();
    }
}
