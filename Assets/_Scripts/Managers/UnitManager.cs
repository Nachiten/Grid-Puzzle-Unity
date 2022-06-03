using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    
    public BaseUnit playerPrefab;
    // private List<ScriptableUnit> units;

    private void Awake()
    {
        Instance = this;
        // units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void spawnPlayer()
    {
        Transform unitParent = GameObject.Find("Units").transform;

        BaseUnit spawnedPlayer = Instantiate(playerPrefab, unitParent);
        
        Tile randomSpawnTile = GridManager.Instance.getHeroSpawnTile();
        randomSpawnTile.SetUnit(spawnedPlayer);

        // Change game state to following state
        //GameManager.Instance.changeState(GameState.spawnEnemies);
    }

    // public void spawnEnemies()
    // {
    //     int enemyCount = 1;
    //
    //     for (int i = 0; i < enemyCount; i++)
    //     {
    //         BaseEnemy randomPrefab = getRandomUnit<BaseEnemy>(Faction.Enemy);
    //         BaseEnemy spawnedEnemy = Instantiate(randomPrefab);
    //         //var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();
    //
    //         // randomSpawnTile.SetUnit(spawnedEnemy);
    //     }
    //
    //     GameManager.Instance.changeState(GameState.heroesTurn);
    // }

    // private T getRandomUnit<T>(Faction faction) where T : BaseUnit
    // {
    //     return (T) units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    // }
    //
    // public void setSelectedHero(BaseHero hero)
    // {
    //     selectedHero = hero;
    //     MenuManager.Instance.showSelectedHero(hero);
    // }
}