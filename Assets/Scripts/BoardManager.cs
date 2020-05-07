using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public int columns = 8;
    public int rows = 8;
    private Transform boardHolder;

    public GameObject[] floorTiles, outerWallTiles, wallTiles;
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;
    public GameObject exitTile;

    private List<Vector2> gridPositions = new List<Vector2>();

    void InitializeList()
    {
        gridPositions.Clear();
        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector2(x, y));
            }
        }
    }

    Vector2 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector2 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector2 randomPosition = RandomPosition();
            GameObject tileChoice = GetRandomInArray(tileArray);
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectAtRandom(wallTiles, 5, 9);
        LayoutObjectAtRandom(foodTiles, 1, 5);
        int enemies = (int)System.Math.Log(level, 2);
        LayoutObjectAtRandom(enemyTiles, enemies, enemies);
        Instantiate(exitTile, new Vector2(columns - 1, rows - 1), Quaternion.identity);
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate;
                if (x == -1 || y == -1 || x == columns || y == rows)
                {
                    toInstantiate = GetRandomInArray(outerWallTiles);
                }
                else
                {
                    toInstantiate = GetRandomInArray(floorTiles);
                }
                GameObject instance = Instantiate(toInstantiate, new Vector2(x, y), Quaternion.identity);
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    GameObject GetRandomInArray(GameObject[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
