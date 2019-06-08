using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCoin : MonoBehaviour
{
    private Vector3 InitialPosition;
    private Vector3 Temp;
    private float RandomOffset;

    void Start()
    {
        InitialPosition = transform.position;
        Temp = InitialPosition;
        RandomOffset = Random.value * 5;
    }

    void Update()
    {
        Temp.y = InitialPosition.y + 0.5f + 0.2f * Mathf.Sin(Time.time * 3 + RandomOffset);
        transform.position = Temp;
        transform.Rotate(Vector3.forward * Time.deltaTime * 50);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            CrystalCount[] components = GameObject.FindObjectsOfType<CrystalCount>();
            foreach (CrystalCount comp in components)
                comp.AddCrystal = true;

            Destroy(gameObject);
        }
    }
}
