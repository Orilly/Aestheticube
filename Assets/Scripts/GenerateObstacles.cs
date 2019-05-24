using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject player;

    public GameObject obstacle;
    public GameObject ramp;

    public Vector2 obstacleDistance;
    public float renderDistance;
    public float trackWidth;
    public Vector2Int obstaclesPerCycle;

    public float chanceOfRamp = 0.1f;
    public Vector2Int obstaclesPerRamp;
    public Vector2 rampDistance;

    //private GameObject[] obstaclesArray = new GameObject[50];
    //private int cycler = 0;
    private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        GameObject positionGame = new GameObject();
        position = positionGame.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && Vector3.Distance(player.transform.position,position.position) < renderDistance)
        {
            position.position = new Vector3(position.position.x, position.position.y, position.position.z + Random.Range(obstacleDistance.x, obstacleDistance.y));
            if (Random.value < chanceOfRamp)
            {
                MakeRampObstacle();
            }
            else
            {
                MakeObstacle();
            }
        }
    }

    void MakeObstacle()
    {
        int repetions = Random.Range(obstaclesPerCycle.x, obstaclesPerCycle.y);
        for (int i = 0; i < repetions; i++)
        {
            Instantiate(obstacle, new Vector3(Random.Range(-trackWidth,trackWidth), position.position.y, position.position.z), obstacle.transform.rotation);
            position.position = new Vector3(position.position.x, position.position.y, position.position.z + obstacle.transform.localScale.z + 0.1f);
        }
    }

    void MakeRampObstacle()
    {

        Instantiate(ramp, new Vector3(Random.Range(-trackWidth, trackWidth), ramp.transform.position.y, position.position.z - Random.Range(rampDistance.x, rampDistance.y)), ramp.transform.rotation);

        int repetions = Random.Range(obstaclesPerRamp.x, obstaclesPerRamp.y);
        for (int i = 0; i < repetions; i++)
        {
            Instantiate(obstacle, new Vector3(Random.Range(-trackWidth, trackWidth), obstacle.transform.position.y, position.position.z), obstacle.transform.rotation);
            position.position = new Vector3(position.position.x, position.position.y, position.position.z + obstacle.transform.localScale.z + 0.1f);
        }
    }
}
