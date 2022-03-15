using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoShooting : MonoBehaviour
{
    //Vitesse de la munition

    public float ammoSpeed;   //Mettre une valeur pour la vitesse

    //Créer le "corp" de la munition

    private Rigidbody2D theRB;

    public player player;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" de la munition
    }

    
    void Update()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, ammoSpeed);    //Faire en sorte que la munition avance tout droit
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Zombie"))
        {
            player.zombKillCount ++;
            player.coins ++;

            Destroy(gameObject);

        }

        if (collision.transform.CompareTag("Crasheur"))
        {
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Boss"))
        {
             Destroy(gameObject);

            
        }

        if (collision.transform.CompareTag("DestroyAmmoZone"))
        {
            Destroy(gameObject);
        }


    }
}
