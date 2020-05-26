using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBomb : MonoBehaviour
{
    public float throwForce = 1.5f;
    public GameObject bombPrefab;
    public int amount = 4;
    private int _currentAmount;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currentAmount < amount)
        {
            PlaceBomb();
            _currentAmount++;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Explode();
        }
    }

    void PlaceBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.LookRotation(Camera.main.transform.forward.normalized));
        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward.normalized * throwForce, ForceMode.Impulse);
    }

    void Explode()
    {
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("BOMBY"))
        {
            CapsuleCollider boom = b.GetComponent<CapsuleCollider>();

            if (boom)
            {
                boom.enabled = true;
                Destroy(b, 0.1f);
            }
        }
    }
}
