using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawn : MonoBehaviour
{
    public GameObject[] buildingBlocks;
    public int gridZ;
    public int gridX;
    public int gridY;
    public float gridSpacing = 1f;
    public float gridSpacingY = 1f;
    public Vector3 gridLocation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTheGrid();
    }

    void SpawnTheGrid()
    {
        for(int x = 0; x < gridX; x ++)
        {
            for (int y = 0; y < gridY; y++)
            {
                for (int z = 0; z < gridZ; z++)
                {
                    Vector3 spawnPosition = new Vector3(x * gridSpacing, y* gridSpacingY, z * gridSpacing) + gridLocation;
                    ChooseAndPlace(spawnPosition, Quaternion.identity);
                }
            }
        }
    }

    void ChooseAndPlace(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, buildingBlocks.Length);
        GameObject clone = Instantiate(buildingBlocks[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
