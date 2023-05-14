using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        GameManager.instance.playerHealth = GameManager.instance.playerMaxHealth;
        GameManager.instance.pages = 0;
        GameManager.instance.player.schoolOutfit = false;

        SceneManager.LoadScene(sceneName);

    }
}
