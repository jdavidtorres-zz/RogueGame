using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public BoardManager boardScript;
    public float turnDelay = 0.1f;
    public int playerFoodPoints = 100;
    [HideInInspector]
    public bool playerTurrn = true;

    private List<Enemy> enemies = new List<Enemy>();
    private bool enemiesMoving;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if (GameManager.instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<BoardManager>();
    }

    void InitGame()
    {
        boardScript.SetupScene(10);
    }

    void Start()
    {
        enemies.Clear();
        InitGame();
    }

    public void GameOver()
    {
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;

        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[1].moveTime);

        }
        playerTurrn = true;
        enemiesMoving = false;
    }
}
