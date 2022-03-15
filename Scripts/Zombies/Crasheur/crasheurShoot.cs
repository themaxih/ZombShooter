using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crasheurShoot : MonoBehaviour
{
    //Vitesse de la munition

    public float crashaSpeed;   //Mettre une valeur pour la vitesse

    //Créer le "corp" du crasha

    private Rigidbody2D theRB;

    //Dégats sur le joueur

    public hpBar hpBar;

    public player player;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" de la munition
    }


    void Update()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, -crashaSpeed);    //Faire en sorte que le crasha avance tout droit vers le bas
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("player"))
        {
            Destroy(gameObject);
            
            player.currentHealth -= 25;
            hpBar.SetCurrentHealth(player.currentHealth);

        }

        if (collision.transform.CompareTag("DZ"))
        {
            Destroy(gameObject);
        }
    }
}
