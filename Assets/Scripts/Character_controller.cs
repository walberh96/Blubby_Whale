using UnityEngine;

public class Character_controller : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButton(0))
        {
            jump();
        }
    }

    public void jump()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z;
        Vector3 targetPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos.x = transform.position.x;
        targetPos.z = transform.position.z;

        // Smoothly move the character towards the target position
        float speed = 60f;
        float smoothTime = 0.1f;
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime, speed);
    }



}
