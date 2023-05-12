using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Zone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
