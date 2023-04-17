using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject projectile;
    public GameObject groundLay;

    public void Spell1()
    {
        Instantiate(projectile, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        GameManager.instance.isCasting = true;
    }

    public void Spell2()
    {
        Instantiate(groundLay, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        GameManager.instance.isCasting = true;
    }
}
