using System.Collections.Generic;
using UnityEngine;

public class FrontGridManager : GridManager
{
    public static FrontGridManager instance;

    private Dictionary<Vector2, Tile> tiles;
    private Transform parent;
    
    private readonly Vector3 parentPosition = new(-2, -2, -2.51f);
    private readonly Quaternion parentRotation = Quaternion.Euler(0, 0, 0);

    private const string faceName = "Front";
    
    void Awake()
    {
        instance = this;
        parent = GameObject.Find("Tiles " + faceName).transform;
        tiles = new Dictionary<Vector2, Tile>();
    }

    public new void generateGrid()
    {
        Debug.Log("Front grid execute");
        
        Debug.Log(parent);
        Debug.Log(parentPosition);
        Debug.Log(parentRotation);
        Debug.Log(tiles);
        generateParticularGrid(parent, parentPosition, parentRotation, ref tiles);
    }
    
    public new Tile getHeroSpawnTile()
    {
        return getHeroSpawnTile(tiles);
    }
    
    public new Tile getTileAtPosition(Vector2 pos)
    {
        return getTileAtPosition(pos, tiles);
    }

    public new Vector2 getPositionOfTile(Tile tile)
    {
        return getPositionOfTile(tile, tiles);
    }
}
