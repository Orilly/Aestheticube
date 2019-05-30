using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;


    public float forwardForce = 2000f;
    public bool limmitedSpeed { get; set; } = true;
    public float speedLimit = 50f;
    public float sidewaysForce = 500f;

    // Reference to the Rigidbody component called "rb"
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // "Fixed Update" because we are messing with physics.
    void FixedUpdate()
    {
        //print(Mathf.Lerp(forwardForce, 0, (rb.velocity.magnitude / speedLimit)));
        if (limmitedSpeed)
        {
            rb.AddForce(0, 0, Mathf.Lerp(forwardForce, 0, (rb.velocity.magnitude / speedLimit)) * Time.deltaTime);
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if ( Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}