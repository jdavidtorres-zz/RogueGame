using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;
    public static GameManager instance;
    public int playerFoodPoints = 100;
    [HideInInspector] public bool playerTurrn = true;

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
        InitGame();
    }

    void Update()
    {

    }

    public void GameOver()
    {
        enabled = false;
    }
}
