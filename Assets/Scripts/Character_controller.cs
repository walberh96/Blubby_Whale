using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    public int jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            //Debug.Log("Jumped");
            jump();
        }
    }

    public void jump() {

        rb.velocity = Vector3.up*jumpForce;
    }
}
