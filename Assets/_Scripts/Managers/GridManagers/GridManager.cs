using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    public int width = 5, height = 5, tileWidth = 1;
    public Tile grassTile, mountainTile;

    // Patron STATE (ponele)
    private FaceManager actualFaceState;

    private Transform mapTilesParent;
    
    private void Awake()
    {
        Instance = this;
        mapTilesParent = GameObject.Find("Map Tiles").transform;
        
        Assert.IsNotNull(mapTilesParent);
    }

    public void doStart()
    {
        setNewFaceState(FrontGridManager.Instance);
        
        GameManager.Instance.changeState(GameState.spawnPlayer);
    }

    public void setNewFaceState(FaceManager newFaceState)
    {
        if (actualFaceState)
        {
            actualFaceState.currentFace = false;
        }
        
        actualFaceState = newFaceState;
        actualFaceState.currentFace = true;
    }

    public void generateGrid()
    {
        BottomGridManager.Instance.generateGrid();
        BackGridManager.Instance.generateGrid();
        FrontGridManager.Instance.generateGrid();
        TopGridManager.Instance.generateGrid();
        RightGridManager.Instance.generateGrid();
        LeftGridManager.Instance.generateGrid();
        
        GameManager.Instance.changeState(GameState.doOrderedStarts);
    }

    public void generateParticularGrid(Transform parent, Vector3 parentPosition, Quaternion parentRotation, ref Dictionary<Vector2, Tile> tiles)
    {
        for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
        {
            Tile randomTile = Random.Range(0, 6) == 3 ? mountainTile : grassTile;
            Tile spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity, parent);

            //Vector3 localPosition = spawnedTile.transform.localPosition;
            //spawnedTile.name = $"Tile {localPosition.x} {localPosition.y}";
            
            spawnedTile.Init(x, y);

            tiles[new Vector2(x, y)] = spawnedTile;
        }

        parent.position = parentPosition;
        parent.rotation = parentRotation;

        foreach (KeyValuePair<Vector2,Tile> tile in tiles)
        {
            // Set each tile parent to mapTiles
            tile.Value.transform.parent = mapTilesParent;
        }

        parent.position = Vector3.zero;
        parent.rotation = Quaternion.Euler(Vector3.zero);
        
        foreach (KeyValuePair<Vector2,Tile> tile in tiles)
        {
            Transform tileTransform = tile.Value.transform;
            
            // Set each tile parent to the corresponding parent
            tileTransform.parent = parent;
            tileTransform.position = roundVector(tileTransform.position);
            tile.Value.name = $"Tile {tileTransform.localPosition.x} {tileTransform.localPosition.y} {tileTransform.localPosition.z}";
        }
    }

    private Vector3 roundVector(Vector3 vector)
    {
        return new Vector3((float)Math.Round(vector.x, 3), (float)Math.Round(vector.y, 3), (float)Math.Round(vector.z, 3));
    }

    public Tile getHeroSpawnTile()
    {
        return actualFaceState.getHeroSpawnTile();
    }

    public Tile getTileAtPosition(Vector3 pos)
    {
        // actualFaceState.printTiles();
        return actualFaceState.getTileAtPosition(pos);
    }

    // public Vector3 getGlobalPositionOfTile(Tile tile)
    // {
    //     return actualFaceState.getGlobalPositionOfTile(tile);
    // }

    public Tile getHeroSpawnTile(Dictionary<Vector2, Tile> tiles)
    {
        return tiles.Where(t => t.Key.x < width / 2f && t.Value.Walkable).OrderBy(_ => Random.value).First().Value;
    }

    public Tile getTileAtPosition(Vector3 pos, Dictionary<Vector2, Tile> tiles)
    {
        // Print each tile global position
        foreach (KeyValuePair<Vector2, Tile> theTile in tiles)
            Debug.Log("Tile " + theTile.Key + " is in position " + theTile.Value.transform.position);

        Tile tile = tiles.FirstOrDefault(theTile => theTile.Value.transform.position == pos).Value;

        Debug.Log("Tile found: " + tile);
        Debug.Log("Walkable: " + tile.Walkable);
        
        return tile && tile.Walkable ? tile : null;
    }

    private bool vectorsAreApproximatelyEqual(Vector3 vector1, Vector3 vector2)
    {
        return Mathf.Approximately(vector1.x, vector2.x) && 
               Mathf.Approximately(vector1.y, vector2.y) && 
               Mathf.Approximately(vector1.z, vector2.z);
    }

    // public Vector3 getGlobalPositionOfTile(Tile tile, Dictionary<Vector2, Tile> tiles)
    // {
    //     return tile.transform.position;
    // }
}