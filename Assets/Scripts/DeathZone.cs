using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //YOU DIED
        if (other.gameObject.tag == "Player") {
            GameManager.Instance.GameOver();

        }
            
    }
}
