using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossSpawn : MonoBehaviour
{
    public GameObject boss;

    public float respawnTime;

    public Vector2[] placements;

    public player player;


    void Start()
    {
        StartCoroutine(bossSpawning());
    }
    private void bossZombies()
    {
        //Système de génération aléatoire

        int randomNumber = Random.Range(0, placements.Length);

        GameObject b = Instantiate(boss) as GameObject;
        b.transform.position = placements[randomNumber];

        StartCoroutine(bossSpawning());
    }
    IEnumerator bossSpawning()
    {
        yield return new WaitForSeconds(respawnTime);
        bossZombies();

    }

    void Update()
    {
        if (player.currentHealth == 0)
        {
            StopAllCoroutines();


        }
    }
}
