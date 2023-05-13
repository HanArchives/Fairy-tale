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
    enum Scenes { TitleScreen, SampleScene, InteriorTest, Battle1, Tutorial, DryCleaner, SchoolInterior, EndScreen, Inn, SampleScene0, FinalBoss, Cutscene1, Cutscene2, Cutscene3, Cutscene4, Cutscene5, SampleScene1 };
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

    public Transform currentSpawnPoint;

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

    // Wizards battle structure
    public bool astroDefeated;
    public bool lunaDefeated;
    public bool hanDefeated;
    public bool skippyDefeated;
    public bool bumiDefeated;

    public bool rheaDefeated;

    public bool allWizardsDefeated;

    public GameObject rheaSpawn;
    public Transform rheaSpawnPos;
    public bool canSpawnRhea;
    public float rheaTimer;

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

        if(astroDefeated && lunaDefeated && hanDefeated && skippyDefeated && bumiDefeated)
        {
            canSpawnRhea = true;
        }

        if (astroDefeated && lunaDefeated && hanDefeated && skippyDefeated && bumiDefeated && rheaDefeated)
        {
            allWizardsDefeated = true;
            rheaDefeated = false;
        }

        if (allWizardsDefeated == true)
        {
            //LoadCutscene3();
            allWizardsDefeated = false;
        }

        if (canSpawnRhea == true)
        {
            rheaTimer += Time.deltaTime;

            if(rheaTimer >= 1f && rheaTimer <= 1.02f)
            {
                SpawnRhea();
                //canSpawnRhea = false;
                //rheaTimer = 0f;
            }
        }

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
            LoadCutscene3();
            pages = 0;
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
        player.transform.position = currentSpawnPoint.position;
    }

    public void SpawnRhea()
    {
        GameObject a = rheaSpawn;
        Instantiate(a, rheaSpawnPos.position, Quaternion.identity);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 1. Titelscherm
        if(scene.buildIndex == (int)Scenes.TitleScreen)
        {
            HUDAnimator.SetBool("IsTitleScreen", true);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
            currentSpawnPoint.position = (tutorialSpawnPoint.position);
            player.transform.position = (currentSpawnPoint.position);
        }

        // 2. Tutorial
        if (scene.buildIndex == (int)Scenes.Tutorial && previousScene == (int)Scenes.TitleScreen)
        {
            currentSpawnPoint.position = (tutorialSpawnPoint.position);
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 3. Dry cleaner
        if (scene.buildIndex == (int)Scenes.DryCleaner)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 4. Cutscene 1
        if (scene.buildIndex == (int)Scenes.Cutscene1)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        // 5. Samplescene 0
        if (scene.buildIndex == (int)Scenes.SampleScene0 && previousScene == (int)Scenes.Cutscene1)
        {
            currentSpawnPoint.position = (dryCleanerSpawnPoint.position);
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 6. School interior
        if (scene.buildIndex == (int)Scenes.SchoolInterior)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 7. Cutscene 2
        if (scene.buildIndex == (int)Scenes.Cutscene2)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        // 8. Samplescene (battles!)
        if (scene.buildIndex == (int)Scenes.SampleScene)
        {
            currentSpawnPoint.position = schoolExitSpawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 9. Cutscene 3
        if (scene.buildIndex == (int)Scenes.Cutscene3)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        // 10. Cutscene 4
        if (scene.buildIndex == (int)Scenes.Cutscene4)
        {
            currentSpawnPoint.position = spawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        // 11. Inn
        if (scene.buildIndex == (int)Scenes.Inn)
        {
            currentSpawnPoint.position = insideInnSpawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 12. Samplescene1 (final boss)
        if (scene.buildIndex == (int)Scenes.SampleScene1)
        {
            currentSpawnPoint.position = innSpawnPoint.position;
            player.transform.position = (currentSpawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", false);
        }

        // 13. Cutscene 5
        if (scene.buildIndex == (int)Scenes.Cutscene5)
        {
            player.transform.position = (spawnPoint.position);
            HUDAnimator.SetBool("IsTitleScreen", false);
            HUDAnimator.SetBool("IsEndScreen", false);
            HUDAnimator.SetBool("IsInCutscene", true);
        }

        // 14. End screen
        if (scene.buildIndex == (int)Scenes.EndScreen)
        {
            HUDAnimator.SetBool("IsEndScreen", true);
            HUDAnimator.SetBool("IsInCutscene", false);
            player.transform.position = (spawnPoint.position);
        }

        previousScene = scene.buildIndex; // Keeps track of what the previousscene was
    }

    public void AddPage()
    {
        pages++;
    }

    public void LoadCutscene3()
    {
        SceneManager.LoadScene((int)Scenes.Cutscene3);
    }

    public void LoadCutscene5()
    {
        SceneManager.LoadScene((int)Scenes.Cutscene5);
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