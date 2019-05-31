using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public bool invincible { get; set; } = false;
    public GameObject dead;
    public float shatterStrength;
    public float velocityMultiplyer = 0.5f;
    public float TorqueBumpThreshold;
    public float DownForceBumpMinThreshold;
    public AudioClip[] BumpSound;

    private Rigidbody rig;
    private AudioSource audSrc;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        audSrc = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if ((rig.velocity.y > DownForceBumpMinThreshold || rig.angularVelocity.magnitude > TorqueBumpThreshold)/* && !audSrc.isPlaying*/)
        {
            audSrc.PlayOneShot(BumpSound[Random.Range(0,BumpSound.Length)]);
        }
        if (collisionInfo.collider.tag == "Obstacle" && !invincible)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            //Shatter
            Rigidbody rig = gameObject.GetComponent<Rigidbody>();
            Vector3 cubeVelocity = rig.velocity;
            GameObject deadCube = Instantiate(dead, transform.position, transform.rotation);
            for (int child = 0; child < deadCube.transform.childCount; child++)
            {
                deadCube.transform.GetChild(child).GetComponent<Rigidbody>().velocity = new Vector3(cubeVelocity.x * velocityMultiplyer + Random.Range(-shatterStrength,shatterStrength), cubeVelocity.y * velocityMultiplyer + Random.Range(-shatterStrength, shatterStrength), cubeVelocity.z * velocityMultiplyer + Random.Range(-shatterStrength, shatterStrength));
            }
            Destroy(gameObject);
        }
    }
}
