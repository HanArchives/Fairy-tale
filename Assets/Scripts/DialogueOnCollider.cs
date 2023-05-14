using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnCollider : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    public GameObject thisGameObject;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // If the dialogue has started
        {

            if (dialogueManager.sentences.Count == 0)
            {
                //dialogueManager.EndDialogue();
                dialogueManager.DisplayNextSentence(); // Player can continue to the next sentence
            }

            else
            {
                dialogueManager.DisplayNextSentence(); // Player can continue to the next sentence
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogueTrigger.TriggerDialogue(); // Starts the dialogue
        }

        //dialogueTrigger.anim = GameObject.Find("DialogueManager").GetComponent<Animator>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //dialogueManager.EndDialogue();
            Destroy(thisGameObject);
            Debug.Log("Destroy!");
        }
    }
}
