using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;


public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    public void UpdateScore() { 
        scoreTxt.text=GameManager.Instance.score.ToString();
    }

}
