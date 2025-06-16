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
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore; // MAX SCORE
        var playerRecordScore = PlayerPrefs.GetFloat("RecordScore", 0f); // RECORD SCORE
        menuWin.SetActive(true);
        menuWin.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerMaxScore);
        if (playerMaxScore > playerRecordScore)
        {
            playerRecordScore = playerMaxScore;
            PlayerPrefs.SetFloat("RecordScore", (float)playerMaxScore);
            PlayerPrefs.Save();
        }
        menuWin.transform.GetChild(0).GetChild(5).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerRecordScore);
        Debug.Log("My record score is " + playerRecordScore);
    }

    public void LoseGame()
    {
        IsPaused = true;
        var playerMaxScore = player.GetComponent<Hole>().MaxFoodScore; // MAX SCORE
        var playerRecordScore = PlayerPrefs.GetFloat("RecordScore", 0f); // RECORD SCORE
        menuLose.SetActive(true);
        menuLose.transform.GetChild(0).GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SCORE • " + Mathf.Floor(playerMaxScore);
        if (playerMaxScore > playerRecordScore)
        {
            playerRecordScore = playerMaxScore;
            PlayerPrefs.SetFloat("RecordScore", (float)playerMaxScore);
            PlayerPrefs.Save();
        }
        menuLose.transform.GetChild(0).GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RECORD • " + Mathf.Floor(playerRecordScore);
        Debug.Log("My record score is " + playerRecordScore);
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
        if (level.childCount == 1)
        {
            WinGame();
        }
    }
}
