using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject selectedHeroObject, tileObject, tileUnitObject;

    private void Awake()
    {
        Instance = this;
    }

    // public void showTileInfo(Tile tile)
    // {
    //     if (tile == null)
    //     {
    //         tileObject.SetActive(false);
    //         tileUnitObject.SetActive(false);
    //         return;
    //     }
    //
    //     tileObject.GetComponentInChildren<Text>().text = tile.TileName;
    //     tileObject.SetActive(true);
    //
    //     if (tile.OccupiedUnit)
    //     {
    //         tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
    //         tileUnitObject.SetActive(true);
    //     }
    // }

    // public void showSelectedHero(BaseHero hero)
    // {
    //     if (hero == null)
    //     {
    //         selectedHeroObject.SetActive(false);
    //         return;
    //     }
    //
    //     selectedHeroObject.GetComponentInChildren<Text>().text = hero.UnitName;
    //     selectedHeroObject.SetActive(true);
    // }
}