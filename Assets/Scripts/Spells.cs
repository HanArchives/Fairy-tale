using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public GameObject closeRangeProjectile;
    public GameObject longRangeProjectile;
    public GameObject groundLay;

    public void Spell1()
    {
        Instantiate(closeRangeProjectile, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        GameManager.instance.isCasting = true;
    }

    public void Spell2()
    {
        Instantiate(longRangeProjectile, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        GameManager.instance.isCasting = true;
    }

    public void Spell3()
    {
        Instantiate(groundLay, GameManager.instance.player.transform.position, GameManager.instance.player.transform.rotation);
        GameManager.instance.isCasting = true;
    }
}
