using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            // Destroys the following objects when they're double in a scene
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(cam.gameObject);

            return;
        }

        instance = this;

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    //Dont Destroy Objects
    public Player player;
    public Camera cam;


    // Scenes
    enum Scenes { SampleScene };
    public string sceneName;
    public int previousScene = 0;
    public int index;

    // SpawnPoints
    public GameObject spawnPoints;
    public Vector3 spawnPoint;

    // Items
    public int coins;

    // Camera states
    public float camSpeed;
    public bool isWalking;
    public bool isPushing;
    public bool isCasting;
    public float camTimer;

    void Start()
    {
        //spawnPoint = GameObject.Find("spawnPoint").transform.position;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {

    }

    public void LateUpdate()
    {

        if (isWalking)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6f, camSpeed);

            if(GameManager.instance.player.isSpeedBoosting)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 7f, camSpeed);
            }

            if(isPushing)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4f, camSpeed);
            }

            if(isCasting)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 8f, camSpeed);

                camTimer += Time.deltaTime;

                if(camTimer >= 0.5f)
                {
                    isCasting = false;
                    camTimer = 0;
                }
            }
        }

        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5f, camSpeed);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        // Checks which spawnpoint the player needs to move to, from which scene to which scene
        if (scene.buildIndex == (int)Scenes.SampleScene)
        {
            player.transform.position = (spawnPoint);
        }

        previousScene = scene.buildIndex; // Keeps track of what the previousscene was
    }

    public void SaveState()
    {
        string s = "";

        s += coins.ToString() + "|"; // Saves the amount of coins

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (s.buildIndex == (int)Scenes.SampleScene)
        {
            SceneManager.sceneLoaded -= LoadState;
        }
        else
        {
            SceneManager.sceneLoaded -= LoadState;
        }

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        coins = int.Parse(data[0]); // Loads the amount of coins

    }

}