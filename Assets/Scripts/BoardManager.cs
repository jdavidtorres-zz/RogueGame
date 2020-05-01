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
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = GetRandomInArray(floorTiles);
                if (x == -1 || y == -1 || x == columns || y == rows)
                {
                    toInstantiate = GetRandomInArray(outerWallTiles);
                }
                Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
            }
        }
    }

    GameObject GetRandomInArray(GameObject[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
