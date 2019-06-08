using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float forwardForce = 3000f;
    public bool limitedSpeed { get; set; } = true;
    public float speedLimit = 32.5f;
    public float sidewaysForce = 40f;

    private bool paused = false;
    private Vector3 savedVel, savedAngularVel;

    // Reference to the Rigidbody component called "rb"
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // "Fixed Update" because we are messing with physics.
    void FixedUpdate()
    {
        if (!paused)
        {
            //print(Mathf.Lerp(forwardForce, 0, (rb.velocity.magnitude / speedLimit)));
            if (limitedSpeed)
            {
                rb.AddForce(0, 0, Mathf.Lerp(forwardForce, 0, (rb.velocity.magnitude / speedLimit)) * Time.deltaTime);
            }
            else
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);
            }

            if (Input.GetKey("d"))
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

    public void Pause()
    {
        paused = true;
        savedVel = rb.velocity;
        savedAngularVel = rb.angularVelocity;
        rb.isKinematic = true;
    }

    public void UnPause()
    {
        rb.isKinematic = false;
        rb.velocity = savedVel;
        rb.angularVelocity = savedAngularVel;
        paused = false;
    }
}