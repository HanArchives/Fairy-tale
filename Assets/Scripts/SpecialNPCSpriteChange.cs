using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialNPCSpriteChange : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public SpriteRenderer spriteRenderer;
    private Vector3 lastPosition;

    public Vector3 playerposition;
    public Vector3 enemyposition;

    public float enemyYposition;
    public float enemyXposition;

    public Rigidbody2D rigid;

    public bool isBattleNPC;

    private void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        playerposition = new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y, 0); // Makes sure the enemy only tracks the player's position on the X-axis
        enemyposition = new Vector3(rigid.transform.position.x, rigid.transform.position.y, 0); // Makes sure the enemy can move

        enemyXposition = rigid.transform.position.x;
        enemyYposition = rigid.transform.position.y;

        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - lastPosition;
        direction.Normalize();

        /*
        if (playerposition.y > enemyYposition)
        {
            spriteRenderer.sprite = upSprite;
        }

        if (playerposition.y < enemyYposition)
        {
            spriteRenderer.sprite = downSprite;
        }
        */
        
        /*
        if (playerposition.x < enemyXposition && playerposition.y > enemyYposition)
        {
            spriteRenderer.sprite = leftSprite;
        }

        if (playerposition.x < enemyXposition && playerposition.y < enemyYposition)
        {
            spriteRenderer.sprite = leftSprite;
        }

        if (playerposition.x > enemyXposition && playerposition.y > enemyYposition)
        {
            spriteRenderer.sprite = rightSprite;
        }

        if (playerposition.x > enemyXposition && playerposition.y < enemyYposition)
        {
            spriteRenderer.sprite = rightSprite;
        } */

        /////////////////////DE GOEIE
        
        if(!isBattleNPC)
        {

            if (direction.y < 0)
            {
                spriteRenderer.sprite = downSprite;
            }

            if (direction.y > 0)
            {
                spriteRenderer.sprite = upSprite;
            }

            else if (direction.x < 0)
            {
                spriteRenderer.sprite = leftSprite;
            }

            else if (direction.x > 0)
            {
                spriteRenderer.sprite = rightSprite;
            }

        }



        //////////////////////DE NIEUWE
        
        if(isBattleNPC)
        {

            if (playerposition.y < enemyYposition)
            {
                spriteRenderer.sprite = downSprite;
            }

            if (playerposition.y > enemyYposition)
            {
                spriteRenderer.sprite = upSprite;
            }

            else if (playerposition.x < enemyXposition)
            {
                spriteRenderer.sprite = leftSprite;
            }

            else if (playerposition.x > enemyXposition)
            {
                spriteRenderer.sprite = rightSprite;
            }

        }


        lastPosition = currentPosition;
    }
}
