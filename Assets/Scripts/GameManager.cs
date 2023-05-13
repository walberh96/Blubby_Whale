using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Paused,Playing, onMainMenu, onDeathMenu}
    public int score { get; set; }
    private GameState state { get; set; }
    public GameObject InGameUI;
    public GameObject PauseMenu;

    public void Awake()
    {
        Instance = this;   
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        state = GameState.Playing;
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            Debug.Log(state);
            if (state == GameState.Paused)
            {
                ResumeGame();
            }
            else if (state == GameState.Playing)
            {
                PauseGame();
            }
        }
    }

    public void SetScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                //YOU MADE A HIGH SCORE
                PlayerPrefs.SetInt("HighScore", score);
                //Show HIGHSCORE, Hide Pause
                PauseMenu.gameObject.GetComponent<Pause_Menu>().ShowHighScoreMenu();
            }
            else {
                PauseMenu.gameObject.GetComponent<Pause_Menu>().ShowDeathMenu();
            }
        }

        else
        {
            PlayerPrefs.SetInt("HighScore", score);
            //Activate Score ,hide pause
            PauseMenu.gameObject.GetComponent<Pause_Menu>().ShowHighScoreMenu();
        }
    }

    public void increaseScore() {
        score++;
        InGameUI.gameObject.GetComponent<Score_UI>().UpdateScore();
    }

    public void PauseGame() { 
        Time.timeScale = 0;
        state = GameState.Paused;
        PauseMenu.SetActive(true);
        PauseMenu.gameObject.GetComponent<Pause_Menu>().ShowPauseMenu();
        Camera.main.GetComponent<AudioSource>().Pause();


    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        state = GameState.Playing;
        PauseMenu.SetActive(false);
        Camera.main.GetComponent<AudioSource>().Play();
    }

    internal void GameOver()
    {
        Time.timeScale = 0;
        state = GameState.onDeathMenu;
        PauseMenu.SetActive(true);
        SetScore();
        Camera.main.GetComponent<AudioSource>().Stop();
        //Play another sound of death
    }

    public void ExitGame() { 
        Application.Quit();
    }

    public void Restart() {
        state = GameState.Playing;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
