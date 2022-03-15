using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombMovement : MonoBehaviour
{
    //Déplacement du zombie

    public float moveSpeed;

    //Créer le "corp" du zombie

    private Rigidbody2D theRB;

    //Gérer les hp du zombie

    public int zombieMaxHp = 10;
    public int zombieCurrentHp;

    //Dégats sur le joueur

    public hpBar hpBar;

    public player player;


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" du zombie

        zombieCurrentHp = zombieMaxHp;
    }

    void Update()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, -moveSpeed);    //Faire en sorte que le zombie avance tout droit vers le bas

        if(zombieCurrentHp == 0)
        {

            Destroy(gameObject);
            
        }

        if (zombieCurrentHp < 0)
        {

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ammo"))
        {
            
            zombieCurrentHp = zombieCurrentHp - 10;


        }

        if (collision.transform.CompareTag("DZ"))
        {

            zombieCurrentHp = zombieCurrentHp - 11;

            player.currentHealth -= 25;
            hpBar.SetCurrentHealth(player.currentHealth);
        }

        if (collision.transform.CompareTag("player"))
        {
            zombieCurrentHp = zombieCurrentHp - 11;

            player.currentHealth -= 25;
            hpBar.SetCurrentHealth(player.currentHealth);
        }


    }

}
