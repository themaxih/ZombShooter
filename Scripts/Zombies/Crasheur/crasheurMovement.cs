using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crasheurMovement : MonoBehaviour
{
    //Déplacement du crasheur

    public float moveSpeed;

    //Créer le "corp" du crasheur

    private Rigidbody2D theRB;

    //Gérer les hp du crasheur

    public int crasheurMaxHp = 20;
    public int crasheurCurrentHp;

    //Dégats sur le joueur

    public hpBar hpBar;

    public player player;

    //Tire de crasha
    
    public GameObject crasha;   //Intégrer un objet
    public Transform firePoint;   //Intégrer la position, l'orientation, la taille, ... du firePoint


    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" du crasheur

        crasheurCurrentHp = crasheurMaxHp;

        StartCoroutine(Shoot());
    }

    void Update()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, -moveSpeed);    //Faire en sorte que le zombie avance tout droit vers le bas

        if (crasheurCurrentHp == 0)
        {
            Destroy(gameObject);

            player.zombKillCount++;

            player.coins++;
            player.coins++;
            player.coins++;

        }

        if (crasheurCurrentHp < 0)
        {

            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ammo"))
        {

            crasheurCurrentHp = crasheurCurrentHp - 10;


        }

        if (collision.transform.CompareTag("DZ"))
        {

            crasheurCurrentHp = crasheurCurrentHp - 21;

            player.currentHealth -= 25;
            hpBar.SetCurrentHealth(player.currentHealth);
        }

        if (collision.transform.CompareTag("player"))
        {
            crasheurCurrentHp = crasheurCurrentHp - 21;

            player.currentHealth -= 25;
            hpBar.SetCurrentHealth(player.currentHealth);
        }
        
    }
    
    void Crasha()
    {
        GameObject munitions = (GameObject)Instantiate(crasha, firePoint.position, firePoint.rotation);    //Situer d'où part la munition
        munitions.transform.localScale = transform.localScale;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        Crasha();
    }

}