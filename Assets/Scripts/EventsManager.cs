using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance;

    [SerializeField] UnityEvent ScoreUpEvent;
    [SerializeField] UnityEvent ScoreDownEvent;
    [SerializeField] UnityEvent DeathEvent;
    [SerializeField] UnityEvent HighScoreEvent;
    [SerializeField] UnityEvent GamePaused;
    [SerializeField] UnityEvent GameResumed;
    [SerializeField] UnityEvent GameStarted;

    private void Awake()
    {
        Instance = this;
    }

    public void callScoreUpEvent() { 
        ScoreUpEvent.Invoke();
    }
    public void callScoreDownEvent()
    {
        ScoreDownEvent.Invoke();
    }
    public void callDeathEvent()
    {
        DeathEvent.Invoke();
    }
    public void callHighScoreEvent()
    {
        HighScoreEvent.Invoke();
    }
    public void callGamePausedEvent()
    {
        GamePaused.Invoke();
    }
    public void callGameResumedEvent()
    {
        GameResumed.Invoke();
    }
    public void callGameStartedEvent()
    {
        GameStarted.Invoke();
    }
}
