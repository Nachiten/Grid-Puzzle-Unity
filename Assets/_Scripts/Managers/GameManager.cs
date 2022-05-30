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
                GridManager.Instance.generateGrid();
                break;
            case GameState.spawnHeroes:
                UnitManager.Instance.spawnHeroes();
                break;
            // case GameState.SpawnEnemies:
            //     UnitManager.Instance.SpawnEnemies();
            //     break;
            // case GameState.HeroesTurn:
            //     break;
            // case GameState.EnemiesTurn:
            //     break;
            // default:
            //     throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}

public enum GameState
{
    generateGrid = 0,
    spawnHeroes = 1,
    spawnEnemies = 2,
    heroesTurn = 3,
    enemiesTurn = 4
}