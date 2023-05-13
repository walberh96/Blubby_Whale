using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Score_UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreTxt,runAwayTxt;
    [SerializeField]
    private GameObject PauseBtn;
    [SerializeField] private float appearDuration = 1f;
    [SerializeField] private float scaleDuration = 1f;
    [SerializeField] private float fadeDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        StartCoroutine(AnimateText());
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

    private IEnumerator AnimateText()
    {
        // Set the initial values
        runAwayTxt.color = new Color(runAwayTxt.color.r, runAwayTxt.color.g, runAwayTxt.color.b, 0f);
        runAwayTxt.transform.localScale = Vector3.zero;

        // Appear animation
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / appearDuration;
            runAwayTxt.color = new Color(runAwayTxt.color.r, runAwayTxt.color.g, runAwayTxt.color.b, t);
            yield return null;
        }

        // Scale animation
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / scaleDuration;
            runAwayTxt.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 1.5f, t);
            yield return null;
        }

        // Fade animation
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeDuration;
            runAwayTxt.color = new Color(runAwayTxt.color.r, runAwayTxt.color.g, runAwayTxt.color.b, 1f - t);
            yield return null;
        }

        // Destroy the object when the animation is finished
        Destroy(runAwayTxt.gameObject);
    }

}
