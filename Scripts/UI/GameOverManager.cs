using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public player player;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (player.currentHealth == 0)
        {
            gameOverUI.SetActive(true);
        }
    }
}
