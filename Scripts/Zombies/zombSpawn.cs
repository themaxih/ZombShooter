using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class zombSpawn : MonoBehaviour
{
    public GameObject zombie;
    
    public Vector2[] placements;

    public float respawnTime;

    public player player;

    //Gérer le timer

    public int tempsQuiPasse;

    public TMP_Text textTimer;


    void Start()
    {
        StartCoroutine(zombSpawning());   //Créer une coroutine

        //Gérer le temps qui passe

        StartCoroutine(tQuiPasse());

        respawnTime = 3f;

    }
    private void spawnZombies()
    {
        //Système de génération aléatoire

        int randomNumber = Random.Range(0, placements.Length);

        GameObject z = Instantiate(zombie) as GameObject;
        z.transform.position = placements[randomNumber];

        StartCoroutine(zombSpawning());
    }

    public void Update()
    {
        if (tempsQuiPasse > 5 && tempsQuiPasse < 20)
        {
            respawnTime = 2f;
        }

        if (tempsQuiPasse > 20 && tempsQuiPasse < 40)
        {
            respawnTime = 1.75f;
        }

        if (tempsQuiPasse > 40 && tempsQuiPasse < 60)
        {
            respawnTime = 1.5f;
        }

        if (tempsQuiPasse > 60 && tempsQuiPasse < 80)
        {
            respawnTime = 1.25f;
        }

        if (tempsQuiPasse > 80 && tempsQuiPasse < 120)
        {
            respawnTime = 1f;
        }

        if (tempsQuiPasse > 120 && tempsQuiPasse < 140)
        {
            respawnTime = 0.9f;
        }

        if (tempsQuiPasse > 140 && tempsQuiPasse < 160)
        {
            respawnTime = 0.8f;
        }

        if (tempsQuiPasse > 160 && tempsQuiPasse < 180)
        {
            respawnTime = 0.7f;
        }

        if (tempsQuiPasse > 180 && tempsQuiPasse < 200)
        {
            respawnTime = 0.6f;
        }

        if (tempsQuiPasse > 200)
        {
            respawnTime = 0.5f;
        }

        if (tempsQuiPasse > 250)
        {
            respawnTime = 0.3f;
        }
        
        if (tempsQuiPasse > 400)
        {
            respawnTime = 0.2f;
        }

        if (tempsQuiPasse > 700)
        {
            respawnTime = 0.1f;
        }

        textTimer.text = tempsQuiPasse.ToString();

        if (player.currentHealth == 0)
        {
            StopAllCoroutines();
        }
    }

    private void tPasse()
    {
        tempsQuiPasse++;
        StartCoroutine(tQuiPasse());
    }
    IEnumerator zombSpawning()
    {

        yield return new WaitForSeconds(respawnTime);
        spawnZombies();
        
    }

    IEnumerator tQuiPasse()
    {
        yield return new WaitForSeconds(1);
        tPasse();

    }
}
