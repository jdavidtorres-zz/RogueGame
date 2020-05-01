using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BoardManager boardScript;

    private void Awake()
    {
        boardScript = GetComponent<BoardManager>();
    }

    void InitGame()
    {
        boardScript.SetupScene();
    }

    void Start()
    {
        InitGame();
    }

    void Update()
    {

    }
}
