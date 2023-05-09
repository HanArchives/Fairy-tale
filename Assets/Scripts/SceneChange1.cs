using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange1 : MonoBehaviour
{
    // Assign the name of the scene you want to load in the Inspector
    public string sceneName;

    // This method is called when the button is clicked
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("is pressed");
    }
}
