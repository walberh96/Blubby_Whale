using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTxt;
    [SerializeField]
    private GameObject PauseBtn;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            PauseBtn.SetActive(true);
        }
        else {
            PauseBtn.SetActive(false);
        }
    }

    public void UpdateScore() { 
        scoreTxt.text=GameManager.Instance.score.ToString();
    }

}
