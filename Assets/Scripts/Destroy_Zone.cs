using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Zone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.Instance.GameOver();
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
