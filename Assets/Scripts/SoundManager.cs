using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip

        // General SFX
        spendCoinsSound, talkSound, teleportSound,

        //Player SFX
        playerHitSound, jumpSound, landSound, playerWalkSound, playerHurtSound, playerReviveSound, diveSound, playerClimbSound,

        // Hammer SFX
        smashSound, pullSound, pullSound2, chargeSound,

        //Enemy SFX
        enemyHitSound, enemyDeathSound, enemyWalkSound, fireSound,

        //Object SFX
        coinSound, equipSound, unequipSound, healSound, boingSound,

        //UI SFX
        confirmSound, openSound, closeSound, buttonSound,

        // Magic SFX
        spellSound;

    /*
        SoundManager.PlaySound("playerWalkSound");
    */

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        teleportSound = Resources.Load<AudioClip>("88_Teleport_02");

        coinSound = Resources.Load<AudioClip>("079_Buy_sell_01");

        playerHitSound = Resources.Load<AudioClip>("61_Hit_03");
        playerWalkSound = Resources.Load<AudioClip>("03_Step_grass_03");
        playerHurtSound = Resources.Load<AudioClip>("15_Impact_flesh_02");
        playerReviveSound = Resources.Load<AudioClip>("30_Revive_03");
        playerClimbSound = Resources.Load<AudioClip>("42_Cling_climb_03");

        jumpSound = Resources.Load<AudioClip>("30_Jump_03");
        diveSound = Resources.Load<AudioClip>("52_Dive_03");
        landSound = Resources.Load<AudioClip>("45_Landing_1");

        pullSound = Resources.Load<AudioClip>("22_Slash_04");
        pullSound2 = Resources.Load<AudioClip>("35_Miss_Evade_02");
        smashSound = Resources.Load<AudioClip>("56_Attack_03");
        chargeSound = Resources.Load<AudioClip>("04_Fire_explosion_04_medium");

        enemyHitSound = Resources.Load<AudioClip>("61_Hit_03");
        enemyDeathSound = Resources.Load<AudioClip>("69_Enemy_death_01");
        enemyWalkSound = Resources.Load<AudioClip>("03_Step_grass_03");
        fireSound = Resources.Load<AudioClip>("04_Fire_explosion_04_medium");

        healSound = Resources.Load<AudioClip>("02_Heal_02");

        equipSound = Resources.Load<AudioClip>("070_Equip_10");
        unequipSound = Resources.Load<AudioClip>("071_Unequip_01");
        boingSound = Resources.Load<AudioClip>("25_Wind_01");

        openSound = Resources.Load<AudioClip>("092_Pause_04");
        closeSound = Resources.Load<AudioClip>("098_Unpause_04");
        confirmSound = Resources.Load<AudioClip>("013_Confirm_03");
        buttonSound = Resources.Load<AudioClip>("051_use_item_01");

        spellSound = Resources.Load<AudioClip>("04_Fire_explosion_04_medium");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "teleportSound":
                audioSrc.PlayOneShot(teleportSound);
                break;

            case "coinSound":
                audioSrc.PlayOneShot(coinSound);
                break;

            case "playerHitSound":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "playerWalkSound":
                audioSrc.PlayOneShot(playerWalkSound);
                break;
            case "playerHurtSound":
                audioSrc.PlayOneShot(playerHurtSound);
                break;
            case "playerReviveSound":
                audioSrc.PlayOneShot(playerReviveSound);
                break;
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "diveSound":
                audioSrc.PlayOneShot(diveSound);
                break;
            case "landSound":
                audioSrc.PlayOneShot(landSound);
                break;
            case "playerClimbSound":
                audioSrc.PlayOneShot(playerClimbSound);
                break;

            case "smashSound":
                audioSrc.PlayOneShot(smashSound);
                break;
            case "pullSound":
                audioSrc.PlayOneShot(pullSound);
                break;
            case "pullSound2":
                audioSrc.PlayOneShot(pullSound2);
                break;
            case "chargeSound":
                audioSrc.PlayOneShot(chargeSound);
                break;

            case "enemyWalkSound":
                audioSrc.PlayOneShot(enemyWalkSound);
                break;
            case "enemyHitSound":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "enemyDeathSound":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "fireSound":
                audioSrc.PlayOneShot(fireSound);
                break;

            case "boingSound":
                audioSrc.PlayOneShot(boingSound);
                break;
            case "equipSound":
                audioSrc.PlayOneShot(equipSound);
                break;
            case "unequipSound":
                audioSrc.PlayOneShot(unequipSound);
                break;
            case "openSound":
                audioSrc.PlayOneShot(openSound);
                break;
            case "closeSound":
                audioSrc.PlayOneShot(closeSound);
                break;
            case "buttonSound":
                audioSrc.PlayOneShot(buttonSound);
                break;

            case "healSound":
                audioSrc.PlayOneShot(healSound);
                break;

            case "spellSound":
                audioSrc.PlayOneShot(spellSound);
                break;

        }
    }

    public static void PlayMusic(string clip)
    {
        switch (clip)
        {
            case "enemyHitSound":
                audioSrc.PlayOneShot(enemyHitSound);
                break;

            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }

    }
}
