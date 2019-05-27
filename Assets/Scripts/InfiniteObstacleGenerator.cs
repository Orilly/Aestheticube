using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteObstacleGenerator : MonoBehaviour
{
    public GameObject Obstacle, OccilatingObstacle, Ramp;

    // Numbers
    private float StartOffset = 20f;
    private float GenerationDistance = 100f;
    private float ObstacleInterval = 10f;
    private float RampStartDistance = 250f;
    private float OccilatingObstacleStartDistance = 500f;
    private float RampInterval = 75f;
    private Vector2Int ObstaclesPerRamp = new Vector2Int(8, 12);

    private GameObject Player;
    private float GroundScaleX; //Track width
    private float GeneratedUpTo;
    private float LastRamp = float.MinValue;
    private List<GameObject> GeneratedObjects = new List<GameObject>();
    private List<GameObject> ToDelete = new List<GameObject>();

    void Start()
    {
        Player = GameObject.Find("Player");
        GeneratedUpTo = Player.transform.position.z + StartOffset - ObstacleInterval;
        GroundScaleX = GameObject.Find("Ground").transform.localScale.x;
    }

    void Update()
    {
        if (Player == null) return;
        
        if (GeneratedUpTo < Player.transform.position.z + GenerationDistance)
        {
            GeneratedUpTo += ObstacleInterval;

            if (GeneratedUpTo > RampStartDistance && Random.value < 0.33f && LastRamp < GeneratedUpTo - RampInterval)
            {
                LastRamp = GeneratedUpTo;

                GeneratedObjects.Add(Instantiate(Ramp, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), -0.25f, GeneratedUpTo + 2f), Ramp.transform.rotation));
                GeneratedUpTo += Ramp.transform.localScale.y + 0.1f;
                int repeats = Random.Range(ObstaclesPerRamp.x, ObstaclesPerRamp.y);
                for (int i = 0; i < repeats; i++)
                {
                    GeneratedObjects.Add(Instantiate(Obstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 1, GroundScaleX / 2 - 1), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    GeneratedUpTo += Obstacle.transform.localScale.z + 0.1f;
                }
            }
            else if (GeneratedUpTo > OccilatingObstacleStartDistance && Random.value < 0.55f)
            {
                GeneratedObjects.Add(Instantiate(OccilatingObstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
            }
            else
            {
                GeneratedObjects.Add(Instantiate(Obstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 1, GroundScaleX / 2 - 1), 0, GeneratedUpTo + 2f), Obstacle.transform.rotation));
            }
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
