using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator; // Animator for the DialogueBox
    public Animator animator3; // Animator for the "Talk" text pop-up above an NPC

    public Queue<string> sentences;

    public float canCastAgainTimer;
    public bool canCastAgainTimerRun;

    public TalkButton talkButton;

    void Awake()
    {
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Update()
    {/*

        if(canCastAgainTimerRun == true)
        {
            canCastAgainTimer += Time.deltaTime;

            if (canCastAgainTimer <= 2f)
            {
                GameManager.instance.canCast = false;
            }

            if (canCastAgainTimer >= 2f)
            {
                GameManager.instance.canCast = true;
                canCastAgainTimerRun = false;
                canCastAgainTimer = 0f;
            }
        }

        if (canCastAgainTimerRun == false)
        {
            canCastAgainTimer = 0f;
        }
        */
    }

    public void AnimatorSearch() // Function to search for the "Talk" text pop-up animator, needs to run every time a scene starts
    {
        //animator3 = GameObject.Find("NPCCanvas").GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsActive", true); // Opens the dialogue box
        animator3.SetBool("IsActive", false); // Disappears the "Talk" text pop-up

        SoundManager.PlaySound("buttonSound");

        GameManager.instance.isTalking = true;

        GameManager.instance.canCast = false;

        nameText.text = dialogue.npcname;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        SoundManager.PlaySound("buttonSound");

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        GameManager.instance.canCast = false;

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        /*
        animator.SetBool("IsActive", false); // Closes the dialogue box
        //SoundManager.PlaySound("buttonSound");
        GameManager.instance.isTalking = false;
        GameManager.instance.canCast = true;
        animator3.SetBool("IsActive", true); // Disappears the "Talk" text pop-up
        animator = animator.GetComponent<Animator>();
        */

        if (talkButton.isBattleEnemy)
        {
            Destroy(talkButton.gameObject);
            GameObject a = talkButton.spawnEnemy;
            Instantiate(a, talkButton.transform.position, Quaternion.identity);

            animator.SetBool("IsActive", false); // Closes the dialogue box
                                                 //SoundManager.PlaySound("buttonSound");
            GameManager.instance.isTalking = false;
            GameManager.instance.canCast = true;
            animator3.SetBool("IsActive", true); // Disappears the "Talk" text pop-up
            animator = animator.GetComponent<Animator>();
        }

        if (!talkButton.isBattleEnemy)
        {
            animator.SetBool("IsActive", false); // Closes the dialogue box
                                                 //SoundManager.PlaySound("buttonSound");
            GameManager.instance.isTalking = false;
            GameManager.instance.canCast = true;
            animator3.SetBool("IsActive", true); // Disappears the "Talk" text pop-up
            animator = animator.GetComponent<Animator>();
        }
    }
}