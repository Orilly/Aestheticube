using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteObstacleGenerator : MonoBehaviour
{
    public GameObject Obstacle, OccilatingObstacle, BouncingObstacle, Ramp;

    // Numbers
    public float StartOffset = 50f;
    public float GenerationDistance = 100f;
    public float ObstacleInterval = 10f;
    public float RampStartDistance = 250f;
    public float OccilatingObstacleStartDistance = 500f;
    public float BouncingObstacleStartDistance = 1000f;
    public float RampInterval = 75f;
    public float SpaceBeforeRamp = 10f;
    public Vector2Int ObstaclesPerRamp = new Vector2Int(20,30);
    public bool bouncingObstacleUnlocked { get; set; }
    public Vector2 bounceHeight = new Vector2(4,8);

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
                GeneratedUpTo += SpaceBeforeRamp;

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
            else if (bouncingObstacleUnlocked && GeneratedUpTo > BouncingObstacleStartDistance && Random.value < 0.1f)
            {
                //print((int)((GeneratedUpTo - BouncingObstacleStartDistance + 500) / 500));
                for (int i = 0; i < (int)((GeneratedUpTo - BouncingObstacleStartDistance + 500) / 500); i++)
                {
                    GeneratedObjects.Add(Instantiate(BouncingObstacle, new Vector3(Random.Range(-GroundScaleX / 2 + 2, GroundScaleX / 2 - 2), Random.Range(bounceHeight.x, bounceHeight.y), GeneratedUpTo + 2f), Obstacle.transform.rotation));
                    GeneratedUpTo += Obstacle.transform.localScale.z + 0.1f;
                }
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
