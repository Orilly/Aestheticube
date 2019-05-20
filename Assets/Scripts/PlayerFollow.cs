using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public GameManager manager;

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameHasEnded)
        {
            transform.position = player.position + offset;
        }
    }
}
