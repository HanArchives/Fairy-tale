using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject closeRangeProjectile;
    public GameObject longRangeProjectile;
    public GameObject groundLay;

    public GameObject[] spellPrefabs;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spell1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Spell2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Spell3();
        }

    }


    public void Spell1()
    {
        //Instantiate(closeRangeProjectile, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        //GameManager.instance.isCasting = true;

        GameManager.instance.shootProjectile.projectilePrefab = spellPrefabs[0];
        GameManager.instance.shootProjectile.projectileSpeed = 2f; // The speed at which the projectile is launched
        GameManager.instance.canCast = true;
        GameManager.instance.spellDamage = 1f;
    }

    public void Spell2()
    {
        //Instantiate(longRangeProjectile, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        //GameManager.instance.isCasting = true;

        GameManager.instance.shootProjectile.projectilePrefab = spellPrefabs[1];
        GameManager.instance.shootProjectile.projectileSpeed = 6f; // The speed at which the projectile is launched
        GameManager.instance.canCast = true;
        GameManager.instance.spellDamage = 0.5f;
    }

    public void Spell3()
    {
        //Instantiate(groundLay, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        //GameManager.instance.isCasting = true;

        GameManager.instance.shootProjectile.projectilePrefab = spellPrefabs[2];
        GameManager.instance.shootProjectile.projectileSpeed = 0f; // The speed at which the projectile is launched
        GameManager.instance.canCast = true;
        GameManager.instance.spellDamage = 1f;
    }
}
