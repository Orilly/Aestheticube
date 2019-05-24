using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteObstacleGenerator : MonoBehaviour
{
    public GameObject Obstacle, OccilatingObstacle, Ramp;
     float StartOffset = 20f;
     float GenerationDistance = 100f;
     float ObstacleInterval = 10f;
     Vector2Int ObstaclesPerRamp = new Vector2Int(8, 12);

    private GameObject Player;
    private float GroundScaleX; //Track width
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
            switch (Random.Range(0, 6))
            {
                case 0:
                case 1:
                case 2:
                    GeneratedObjects.Add(Instantiate(Obstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 1, GroundScaleX / 2 - 1), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    break;
                case 3:
                case 4:
                    GeneratedObjects.Add(Instantiate(OccilatingObstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    break;
                case 5:
                    GeneratedObjects.Add(Instantiate(Ramp, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), -0.25f, GeneratedUpTo + 2f), Ramp.transform.rotation));
                    GeneratedUpTo += Ramp.transform.localScale.y + 0.1f;
                    int repeats = Random.Range(ObstaclesPerRamp.x, ObstaclesPerRamp.y);
                    for (int i = 0; i < repeats; i++)
                    {
                        GeneratedObjects.Add(Instantiate(Obstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 1, GroundScaleX / 2 - 1), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                        GeneratedUpTo += Obstacle.transform.localScale.z + 0.1f;
                    }
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
