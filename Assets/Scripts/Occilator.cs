using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occilator : MonoBehaviour
{
    public int OccilationSpeed = 2;

    private float X1;
    private Vector3 temp;

    void Start()
    {
        X1 = transform.position.x;
    }

    void Update()
    {
        temp = transform.position;
        temp.x = X1 + Mathf.Sin(Time.time * OccilationSpeed);
        transform.position = temp;
    }
}
