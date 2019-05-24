using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occilator : MonoBehaviour
{
    public int OccilationSpeed = 2;

    private float X1;
    private Vector3 temp;
    private float randomOffset;

    void Start()
    {
        X1 = transform.position.x;
        randomOffset = Random.value*2;
    }

    void Update()
    {
        temp = transform.position;
        temp.x = X1 + Mathf.Sin((Time.time + randomOffset) * OccilationSpeed);
        transform.position = temp;
    }
}
