using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string[] sceneNames;
    public Animator anim;
    public bool isInRange; // Can the player move through the door?

    public Animator anim2;

    void Start()
    {
        isInRange = false;
    }

    void Update()
    {
        if (isInRange == true) // If the player can move through the door
        {
            anim2.SetBool("IsActive", true);

            if (Input.GetKeyDown(KeyCode.T)) // If the left shift button is pressed
            {
                ChangeScene();
            }
        }

        if(isInRange == false)
        {
            anim2.SetBool("IsActive", false);
        }
    }


    // Colliders of the interactzones around doors
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", true);
            GameManager.instance.sceneName = sceneNames[Random.Range(0, sceneNames.Length)]; // Gets which scene the player is supposed to move to
            isInRange = true; // The player can move through the door
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", false);
            isInRange = false; // The player can't move through the door
        }

    }

    public void ChangeScene()
    {
        string sceneName = GameManager.instance.sceneName;
        anim.SetBool("IsActive", false);
        isInRange = false;
        GameManager.instance.SaveState();
        SceneManager.LoadScene(sceneName);
    }
}