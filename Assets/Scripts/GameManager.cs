using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameDuration;
    [SerializeField] private float timeLeft;
    [SerializeField] private GameObject menuLose;
    [SerializeField] private GameObject menuWin;
    [SerializeField] private Transform level;
    [SerializeField] private GameObject player;

    private void Start()
    {
        timeLeft = gameDuration;
        menuLose.SetActive(false);
        menuWin.SetActive(false);
    }

    public void WinGame()
    {
        var playerScore = player.GetComponent<Hole>().FoodScore;
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore;
        menuWin.SetActive(true);
        menuWin.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerScore);
        if (playerScore > playerMaxScore)
        {
            playerMaxScore = playerScore;
            menuWin.transform.GetChild(0).GetChild(5).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerMaxScore);
        }
    }

    public void LoseGame()
    {
        // Implement lose game logic here
        Debug.Log("You lose!");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menuLose.SetActive(false);
        menuWin.SetActive(false);
    }

    public void IsGameOver()
    {
        if (level.childCount == 0)
        {
            WinGame();
        }
    }
}
