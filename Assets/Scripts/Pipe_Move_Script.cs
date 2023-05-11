using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_Move_Script : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= transform.position +(Vector3.left * moveSpeed)* Time.deltaTime;
    }
}
