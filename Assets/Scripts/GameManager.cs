using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Paused,Playing, onMainMenu, onDeathMenu}
    public int score { get; set; }
    public GameState state { get; set; } = GameState.Playing;
    public void Awake()
    {
        Instance = this;   
    }
    // Start is called before the first frame update
    void Start()
    {

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            if (state == GameState.Paused)
            {
                UpdateGameState(GameState.Playing);
            }
            else if (state == GameState.Playing)
            {
                UpdateGameState(GameState.Paused);
            }
        }
    }

    public void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Paused:
                {
                    //Pause the Game  
                    PauseGame();
                    break;
                }
            case GameState.Playing:
                {
                    //Resume the Game
                    ResumeGame();
                    break;
                }
            case GameState.onMainMenu:
                {
                    //Show Main Menu
                    break;
                }
            case GameState.onDeathMenu:
                {
                    //Show Death Menu    
                    break;
                }

        }
    }

    public void SetScore(int score)
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                //YOU MADE A HIGH SCORE
                PlayerPrefs.SetInt("HighScore", score);
                EventsManager.Instance.callHighScoreEvent();
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void increaseScore() {
        score++;
    }

    public void PauseGame() { 
        Time.timeScale = 0;
        state = GameState.Paused;
        EventsManager.Instance.callGamePausedEvent();
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        state = GameState.Playing;
        EventsManager.Instance.callGameResumedEvent();
    }

}
