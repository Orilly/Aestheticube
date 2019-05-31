﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCoin : MonoBehaviour
{
    private Mesh mesh = null;
    public Mesh[] varients;

    private Vector3 InitialPosition;
    private Vector3 Temp;
    private float RandomOffset;

    void Start()
    {
        mesh = varients[Random.Range(0,varients.Length)];
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;

        InitialPosition = transform.position;
        Temp = InitialPosition;
        RandomOffset = Random.value * 5;
    }

    void Update()
    {
        Temp.y = InitialPosition.y + 0.2f * Mathf.Sin(Time.time * 3 + RandomOffset);
        transform.position = Temp;
        transform.Rotate(Vector3.forward * Time.deltaTime * 50);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            FileEditor FileEdit = new FileEditor();
            int tokens = 0;
            try
            {
                tokens = int.Parse(FileEdit.ReadString("Assets/SaveFile")) + 1;
            }
            catch (System.Exception)
            {
                tokens = 0;
            }
            print(tokens.ToString());
            FileEdit.WriteString("Assets/SaveFile", tokens.ToString());
            transform.parent = collision.transform;
            GetComponent<IdleCoin>().enabled = false;
        }
    }
}
