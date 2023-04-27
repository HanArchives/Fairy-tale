using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkButton : MonoBehaviour
{
    public Animator anim;
    public Dialogue dialogueOption;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    public bool isPlayerNear; // Checks if the player is in range of the NPC
    public bool isPlayerTalking; // Checks if the player is talking to the NPC, can continue to the next sentence instead of starting the dialogue

    public float talkTimer;

    void Start()
    {
        //anim = GameObject.Find("NPCCanvas").GetComponent<Animator>();
        dialogueTrigger = GameObject.Find("TalkButton").GetComponent<DialogueTrigger>(); // Finds the button that can activate the dialoguebox
        isPlayerTalking = false;
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    public void Update()
    {
        /*
        if(isPlayerTalking == true)
        {
            talkTimer += Time.deltaTime;
        }

        if (talkTimer >= 0.015) // If this amount of time passes
        {
            talkTimer = 0;
            isPlayerTalking = true; // Checks if the player is talking to the NPC, can continue to the next sentence instead of starting the dialogue
        }
        */

        if (Input.GetKeyUp(KeyCode.T) && isPlayerNear == true && isPlayerTalking == false) // If left shift is pressed and the player is in range
        {
            dialogueTrigger.TriggerDialogue(); // Starts the dialogue

            isPlayerTalking = true;

            
            //TalkTimer(); // Starts the timer



            //isPlayerTalking = true; // Checks if the player is talking to the NPC, can continue to the next sentence instead of starting the dialogue
            

        }

        if (Input.GetKeyDown(KeyCode.T) && isPlayerTalking == true) // If the dialogue has started
        {
            isPlayerNear = false; // Makes sure the player doesn't start up the dialogue again from the start

            if (dialogueManager.sentences.Count == 0)
            {
                dialogueManager.EndDialogue();
                //talkTimer = 0;
            }

            else
            {
                dialogueManager.DisplayNextSentence(); // Player can continue to the next sentence
            }
            //FindObjectOfType<DialogueManager>().DisplayNextSentence();

        }

    }

    // Ranges of the interactzones of NPC's
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", true);
            dialogueTrigger.dialogue = dialogueOption;
            isPlayerNear = true;
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", false);
            isPlayerNear = false;
            isPlayerTalking = false;
            dialogueManager.EndDialogue();
        }

    }

    public void TalkTimer() // Timer starts when the player starts talking to the NPC
    {
        talkTimer += Time.deltaTime;
    }

}