using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBomb : MonoBehaviour
{
    public float throwForce = 1.5f;
    public GameObject bombPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBomb();
        }
    }

    void PlaceBomb()
    {
        Instantiate(bombPrefab, transform.position, transform.rotation);
        Rigidbody rb = bombPrefab.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
