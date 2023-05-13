using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Follow : MonoBehaviour
{

    private Transform playerTransform;
    [SerializeField] private float followDelay = 0.3f;
    [SerializeField] private float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    { 
            Vector3 playerPosition = playerTransform.position;
            Vector3 enemyPosition = transform.position;

            float targetY = playerPosition.y - followDelay;
            float newY = Mathf.Lerp(enemyPosition.y, targetY, Time.deltaTime * moveSpeed);

            transform.position = new Vector3(enemyPosition.x, newY, enemyPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameManager.Instance.GameOver();
            other.gameObject.GetComponent<Animator>().Play("dead");
        }
    }



}
