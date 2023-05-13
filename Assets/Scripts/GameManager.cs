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
            Destroy(dialogueManager.gameObject);
            Destroy(HUD.gameObject);
            Destroy(soundManager.gameObject);
            Destroy(spawnPoint.gameObject);
            Destroy(towerSpawnPoint.gameObject);
            Destroy(tutorialSpawnPoint.gameObject);
            Destroy(dryCleanerSpawnPoint.gameObject);


            player.transform.position = (spawnPoint.position);

            return;
        }

        instance = this;

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    //Dont Destroy Objects
    public Player player;
    public Camera cam;
    public DialogueManager dialogueManager;
    public GameObject HUD;
    public GameObject soundManager;

    // Scenes
    enum Scenes { TitleScreen, SampleScene, InteriorTest, Battle1, Tutorial, DryCleaner, SchoolInterior, EndScreen, Inn, SampleScene0, FinalBoss, Cutscene1, Cutscene2 };
    public string sceneName;
    public int previousScene = 0;
    public int index;

    // SpawnPoints
    public GameObject spawnPoints;
    public Transform spawnPoint;
    public Transform towerSpawnPoint;
    public Transform tutorialSpawnPoint;
    public Transform dryCleanerSpawnPoint;
    public Transform innSpawnPoint;
    public Transform insideInnSpawnPoint;
    public Transform schoolExitSpawnPoint;

    // Items
    public int pages;
    public Text pagesText;

    // Camera states
    public float camSpeed;
    public float regularCamSpeed;
    public bool isWalking;
    public bool isPushing;
    public bool isCasting;
    public bool isBattling;
    public bool isTalking;
    public float camTimer;
    public float walkTimer;

    // Magic
    public ShootProjectile shootProjectile;
    public bool canCast;

    // Player stats
    public float spellDamage;
    public float playerHealth;
    public float playerMaxHealth;
    public Text healthText;
    public Text healthWorldText;
    public Text minosOneText;

    // Title Screen
    public Animator HUDAnimator;

    void Start()
    {
        //spawnPoint = GameObject.Find("spawnPoint").transform.position;
        SceneManager.sceneLoaded += OnSceneLoaded;

        //HUDAnimator = HUD.GetComponent<Animator>();

        regularCamSpeed = camSpeed;
    }

    void Update()
    {
        healthText.text = "Health: " + playerHealth + " / " + playerMaxHealth;

        healthWorldText.text = playerHealth + " / " + playerMaxHealth;

        pagesText.text = "Pages: " + pages + " / " + "6";

        if(isWalking == true)
        {
            walkTimer += Time.deltaTime;

            if(walkTimer >= 0.4f)
            {
                walkTimer = 0;
            }

            if(walkTimer == 0 && player.isSpeedBoosting == false)
            {
                SoundManager.PlaySound("playerWalkSound");
            }
        }

        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        if(playerHealth <= 0)
        {
            Respawn();
        }

        if(pages == 0)
        {
            playerMaxHealth = 9;
        }

        if (pages == 1)
        {
            playerMaxHealth = 8;
        }

        if (pages == 2)
        {
            playerMaxHealth = 7;
        }

        if (pages == 3)
        {
            playerMaxHealth = 6;
        }

        if (pages == 4)
        {
            playerMaxHealth = 5;
        }

        if (pages == 5)
        {
            playerMaxHealth = 4;
        }

        if (pages == 6)
        {
            playerMaxHealth = 3;
        }
    }

    public void LateUpdate()
    {

        if (isWalking)
        {
            //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6f, camSpeed);

            if (GameManager.instance.player.isSpeedBoosting)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 7.25f, camSpeed);
            }

            if (isPushing)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5.5f, camSpeed);
            }

            if (isTalking)
            {
                camSpeed = 0.01f;
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4.5f, camSpeed);
            }
        }

        if(isTalking)
        {
            camSpeed = 0.01f;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4.5f, camSpeed);
        }

        if(!isTalking)
        {
            camSpeed = regularCamSpeed;
        }

        if (isBattling)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 7f, camSpeed);
        }

        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6.5f, camSpeed);
        }

    }

    public void Respawn()
    {
        playerHealth = playerMaxHealth;
        player.transform.position = spawnPoint.position;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == (int)Scenes.TitleScreen)
        {
            HUDAnimator.SetBool("IsTitleScreen", true);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
            player.transform.position = (tutorialSpawnPoint.position);
        }


        if (scene.buildIndex == (int)Scenes.EndScreen && previousScene == (int)Scenes.SchoolInterior)
        {
            HUDAnimator.SetBool("IsEndScreen", true);
            HUDAnimator.SetBool("IsInCutscene", false);
            player.transform.position = (spawnPoint.position);
        }

        /*
        if (scene.buildIndex != (int)Scenes.EndScreen)
        {
            HUDAnimator.SetBool("IsTitleScreen", false);
        }
        */

        if (scene.buildIndex == (int)Scenes.Tutorial && previousScene == (int)Scenes.TitleScreen)
        {
            player.transform.position = (tutorialSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.Tutorial && previousScene == (int)Scenes.Inn)
        {
            player.transform.position = (innSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.SampleScene && previousScene == (int)Scenes.Battle1)
        {
            player.transform.position = (towerSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.SampleScene0 && previousScene == (int)Scenes.DryCleaner)
        {
            player.transform.position = (dryCleanerSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.SampleScene && previousScene == (int)Scenes.SchoolInterior)
        {
            player.transform.position = (dryCleanerSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.SampleScene && previousScene == (int)Scenes.SchoolInterior)
        {
            player.transform.position = (schoolExitSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }


        if (scene.buildIndex == (int)Scenes.SampleScene0 && previousScene == (int)Scenes.DryCleaner)
        {
            player.transform.position = (dryCleanerSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // Checks which spawnpoint the player needs to move to, from which scene to which scene

        /*
        if (scene.buildIndex == (int)Scenes.SampleScene && previousScene != (int)Scenes.Battle1)
        {
            player.transform.position = (spawnPoint.position);
        } */

        if (scene.buildIndex == (int)Scenes.InteriorTest)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.Battle1)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.DryCleaner)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.SchoolInterior)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.FinalBoss)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.Inn && previousScene == (int)Scenes.TitleScreen)
        {
            player.transform.position = (insideInnSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        if (scene.buildIndex == (int)Scenes.Cutscene1)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        previousScene = scene.buildIndex; // Keeps track of what the previousscene was
    }

    public void AddPage()
    {
        pages++;
    }

    public void SaveState()
    {
        string s = "";

        //s += pages.ToString() + "|"; // Saves the amount of coins

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

        //pages = int.Parse(data[0]); // Loads the amount of coins

    }

}