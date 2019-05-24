using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteObstacleGenerator : MonoBehaviour
{
    public GameObject Obstacle, OccilatingObstacle, Ramp;
     float StartOffset = 20f;
     float GenerationDistance = 100f;
     float ObstacleInterval = 10f;

    private GameObject Player;
    private float GroundScaleX;
    private float GeneratedUpTo;
    private List<GameObject> GeneratedObjects = new List<GameObject>();
    private List<GameObject> ToDelete = new List<GameObject>();

    void Start()
    {
        Player = GameObject.Find("Player");
        GeneratedUpTo = Player.transform.position.z + StartOffset;
        GroundScaleX = GameObject.Find("Ground").transform.localScale.x;
    }

    void Update()
    {
        if (Player == null) return;

        // Add some Obstacles
        if (GeneratedUpTo < Player.transform.position.z + GenerationDistance)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    GeneratedObjects.Add(Instantiate(Obstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 1, GroundScaleX / 2 - 1), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    break;
                case 1:
                    GeneratedObjects.Add(Instantiate(OccilatingObstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    break;
            }
            GeneratedUpTo += ObstacleInterval;
        }

        ClearPastObjects();
    }

    private void ClearPastObjects()
    {
        foreach (GameObject O in GeneratedObjects)
        {
            if (O.transform.position.z < Player.transform.position.z - 15f)
            {
                ToDelete.Add(O);
            }
        }
        foreach (GameObject O in ToDelete)
        {
            GeneratedObjects.Remove(O);
        }
        ToDelete.Clear();
    }
}
