using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    public BaseHero selectedHero;

    private List<ScriptableUnit> units;

    private void Awake()
    {
        Instance = this;

        units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void spawnHeroes()
    {
        const int heroCount = 1;

        Transform unitParent = GameObject.Find("Units").transform;

        for (int i = 0; i < heroCount; i++)
        {
            BaseHero randomPrefab = getRandomUnit<BaseHero>(Faction.Hero);
            BaseHero spawnedHero = Instantiate(randomPrefab, unitParent);

            spawnedHero.name = randomPrefab.name;

            Tile randomSpawnTile = GridManager.Instance.getHeroSpawnTile();
            randomSpawnTile.SetUnit(spawnedHero);
        }

        GameManager.Instance.changeState(GameState.spawnEnemies);
    }

    public void spawnEnemies()
    {
        int enemyCount = 1;

        for (int i = 0; i < enemyCount; i++)
        {
            BaseEnemy randomPrefab = getRandomUnit<BaseEnemy>(Faction.Enemy);
            BaseEnemy spawnedEnemy = Instantiate(randomPrefab);
            //var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            // randomSpawnTile.SetUnit(spawnedEnemy);
        }

        GameManager.Instance.changeState(GameState.heroesTurn);
    }

    private T getRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T) units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void setSelectedHero(BaseHero hero)
    {
        selectedHero = hero;
        MenuManager.Instance.showSelectedHero(hero);
    }
}