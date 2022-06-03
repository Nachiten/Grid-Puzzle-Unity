using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        changeState(GameState.generateGrid);
    }

    public void changeState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.generateGrid:
                Debug.Log("[Game Manager] Generating Grid...");
                GridManager.Instance.generateGrid();
                
                break;
            case GameState.doOrderedStarts:
                Debug.Log("[Game Manager] Executing ordered starts...");
                GridManager.Instance.doStart();
                
                break;
            case GameState.spawnPlayer:
                Debug.Log("[Game Manager] Spawning Player...");
                UnitManager.Instance.spawnPlayer();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    generateGrid = 0,
    doOrderedStarts = 1,
    spawnPlayer = 2,
}