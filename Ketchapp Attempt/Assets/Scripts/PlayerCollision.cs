using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public GameObject dead;
    public float shatterStrength;


    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            //Shatter
            Rigidbody rig = gameObject.GetComponent<Rigidbody>();
            Vector3 cubeVelocity = rig.velocity;
            GameObject deadCube = Instantiate(dead, transform.position, transform.rotation);
            for (int child = 0; child < deadCube.transform.childCount; child++)
            {
                deadCube.transform.GetChild(child).GetComponent<Rigidbody>().velocity = new Vector3(cubeVelocity.x + Random.Range(-shatterStrength,shatterStrength), cubeVelocity.y + Random.Range(-shatterStrength, shatterStrength), cubeVelocity.z + Random.Range(-shatterStrength, shatterStrength));
            }
            Destroy(gameObject);
        }
    }
}
