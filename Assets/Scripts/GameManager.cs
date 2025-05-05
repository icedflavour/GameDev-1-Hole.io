using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused;

    [SerializeField] private float gameDuration;
    [SerializeField] private float timeLeft;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject menuLose;
    [SerializeField] private GameObject menuWin;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private Transform level;
    [SerializeField] private GameObject player;

    private void Start()
    {
        IsPaused = false;
        timeLeft = gameDuration;
        menuLose.SetActive(false);
        menuWin.SetActive(false);
        menuPause.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (IsPaused) return;
        timeLeft -= Time.fixedDeltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        if (timeLeft <= 0)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        IsPaused = true;
        var playerScore = player.GetComponent<Hole>().MaxFoodScore; // MAX SCORE
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore; // RECORD SCORE
        menuWin.SetActive(true);
        menuWin.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerScore);
        if (playerScore > playerMaxScore)
        {
            playerMaxScore = playerScore;
            menuWin.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerMaxScore);
        }
    }

    public void LoseGame()
    {
        IsPaused = true;
        var playerScore = player.GetComponent<Hole>().MaxFoodScore; // MAX SCORE
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore; // RECORD SCORE
        menuLose.SetActive(true);
        menuLose.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerScore);
        if (playerScore > playerMaxScore)
        {
            playerMaxScore = playerScore;
            menuLose.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerMaxScore);
        }
    }

    public void PauseGame()
    {
        IsPaused = !IsPaused;
        menuPause.SetActive(IsPaused);
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
