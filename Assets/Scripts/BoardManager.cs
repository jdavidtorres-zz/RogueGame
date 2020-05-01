using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int columns = 8;
    public int rows = 8;

    public GameObject[] floorTiles, outerWallTiles;

    public void SetupScene()
    {
        BoardSetup();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void BoardSetup()
    {
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || y == -1 || x == columns || y == rows)
                {
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                }
            }
        }
    }
}
