using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class crasheurSpawn : MonoBehaviour
{
    public GameObject crasheur;

    public Vector2[] placements;

    public float respawnTime = 5;

    public player player;

    void Start()
    {
        StartCoroutine(crasheurSpawning());
    }
    private void crasheurZombies()
    {
        //Système de génération aléatoire

        int randomNumber = Random.Range(0, placements.Length);

        GameObject c = Instantiate(crasheur) as GameObject;
        c.transform.position = placements[randomNumber];

        StartCoroutine(crasheurSpawning());
    }
    IEnumerator crasheurSpawning()
    {
        yield return new WaitForSeconds(respawnTime);
        crasheurZombies();

    }

    void Update()
    {
        if (player.currentHealth == 0)
        {
            StopAllCoroutines();
        }
    }
}