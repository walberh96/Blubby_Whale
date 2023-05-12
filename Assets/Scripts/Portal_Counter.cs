using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Portal_Counter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Send the score up event
        if (other.tag.Equals("Player")) {
            GameManager.Instance.increaseScore();
        }
    }
}
