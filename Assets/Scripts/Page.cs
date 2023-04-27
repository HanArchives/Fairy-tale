using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{

    public Dialogue dialogueOption;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GameObject.Find("TalkButton").GetComponent<DialogueTrigger>(); // Finds the button that can activate the dialoguebox
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        dialogueTrigger.dialogue = dialogueOption;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T)) // If the dialogue has started
        {

            if (dialogueManager.sentences.Count == 0)
            {
                dialogueManager.EndDialogue();
                Destroy(gameObject);
            }

            else
            {
                dialogueManager.DisplayNextSentence(); // Player can continue to the next sentence
            }
            //FindObjectOfType<DialogueManager>().DisplayNextSentence();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.AddPage();
            //GameManager.instance.playerHealth = GameManager.instance.playerMaxHealth;
            dialogueTrigger.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
