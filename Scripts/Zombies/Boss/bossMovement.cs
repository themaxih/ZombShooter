using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : MonoBehaviour
{
    //Déplacement du boss

    public float moveSpeed;

    //Créer le "corp" du boss

    private Rigidbody2D theRB;

    //Gérer les hp du boss

    public int bossMaxHp = 50;
    public int bossCurrentHp;

    //Gérer les coins

    public player player;

    //Dégats sur le joueur
    
    public hpBar hpBar;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" du boss

        bossCurrentHp = bossMaxHp;
    }

    void Update()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, -moveSpeed);    //Faire en sorte que le boss avance tout droit vers le bas

        if (bossCurrentHp == 0)
        {
            player.zombKillCount++;

            player.coins++;
            player.coins++;
            player.coins++;
            player.coins++;
            player.coins++;

            Destroy(gameObject);

        }

        if (bossCurrentHp < 0)
        {

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ammo"))
        {

            bossCurrentHp = bossCurrentHp - 10;

        }

        if (collision.transform.CompareTag("DZ"))
        {

            bossCurrentHp = bossCurrentHp - 51;

            player.currentHealth -= 50;
            hpBar.SetCurrentHealth(player.currentHealth);

        }

        if (collision.transform.CompareTag("player"))
        {
            bossCurrentHp = bossCurrentHp - 51;


            player.currentHealth -= 50;
            hpBar.SetCurrentHealth(player.currentHealth);
        }


    }

}
