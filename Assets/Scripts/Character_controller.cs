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
        if (((Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }

    public void jump() {

        rb.velocity = Vector3.up*jumpForce;
    }
}
