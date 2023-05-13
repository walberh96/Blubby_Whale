using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    public TMP_Text Pause, Score, HighScore;
    public Button Resume, Restart, Exit;

    public void ShowPauseMenu() {
        Debug.Log("PAUSE");
        HighScore.gameObject.SetActive(false);
        Score.gameObject.SetActive(true);
        Pause.gameObject.SetActive(true);
        Pause.text = "PAUSED";
        Score.text = "Score: " + GameManager.Instance.score.ToString();
        Resume.gameObject.SetActive(true);
        Restart.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
    }
    public void ShowDeathMenu() {
        Debug.Log("DEATH");
        HighScore.gameObject.SetActive(false);
        Score.gameObject.SetActive(true);
        Pause.gameObject.SetActive(true);
        Pause.text = "YOU DIED!";
        Score.text = "Score: " + GameManager.Instance.score.ToString();
        Resume.gameObject.SetActive(false);
        Restart.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void ShowHighScoreMenu() {
        Debug.Log("HIGH SCORE");
        HighScore.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        Pause.gameObject.SetActive(true);
        Pause.text = "YOU DIED!";
        Score.text = "Score: "+GameManager.Instance.score.ToString();
        Resume.gameObject.SetActive(false);
        Restart.gameObject.SetActive(true);
        Exit.gameObject.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();

    }
}
