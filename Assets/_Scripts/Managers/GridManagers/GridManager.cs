using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    
    private int width = 5, height = 5;
    
    // TODO - Fixear problema con la herencia
    public Tile grassTile, mountainTile;
    
    // Patron STATE
    private GridManager actualFaceState;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        actualFaceState = FrontGridManager.instance;
    }

    public void generateGrid()
    {
        Debug.Log("Grid manager execute");
        FrontGridManager.instance.generateGrid();
        BackGridManager.instance.generateGrid();
        TopGridManager.instance.generateGrid();
        BottomGridManager.instance.generateGrid();
        RightGridManager.instance.generateGrid();
        LeftGridManager.instance.generateGrid();
    }

    protected void generateParticularGrid(Transform parent, Vector3 parentPosition, Quaternion parentRotation, ref Dictionary<Vector2, Tile> tiles)
    {
        for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
        {
            Tile randomTile = Random.Range(0, 6) == 3 ? mountainTile : grassTile;
            Tile spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity, parent);

            spawnedTile.name = $"Tile {x} {y}";
            spawnedTile.Init(x, y);

            tiles[new Vector2(x, y)] = spawnedTile;
        }
        
        parent.position = parentPosition;
        parent.rotation = parentRotation;
    }
    
    // public void generateGrid()
    // {
    //     foreach (string faceName in facesNames)
    //     {
    //         Transform parent = GameObject.Find("Tiles " + faceName).transform;
    //         generateGridWithParentInDictionary(parent, faces.GetValueOrDefault(faceName));
    //         setParentTransform(parent, faceName);
    //     }
    //     
    //     GameManager.Instance.changeState(GameState.spawnHeroes);
    // }

    // private void setParentTransform(Transform parent, string faceName)
    // {
    //     switch (faceName)
    //     {
    //         case "Front":
    //             parent.position = new Vector3(-2, -2, -2.51f);
    //             parent.rotation = Quaternion.Euler(0, 0, 0);
    //             break;
    //         case "Back":
    //             parent.position = new Vector3(2, -2, 2.51f);
    //             parent.rotation = Quaternion.Euler(0, 180, 0);
    //             break;
    //         case "Top":
    //             parent.position = new Vector3(-2, 2.51f, -2);
    //             parent.rotation = Quaternion.Euler(90, 0, 0);
    //             break;
    //         case "Bottom":
    //             parent.position = new Vector3(-2, -2.51f, 2);
    //             parent.rotation = Quaternion.Euler(-90, 0, 0);
    //             break;
    //         case "Right":
    //             parent.position = new Vector3(2.51f, -2, 2);
    //             parent.rotation = Quaternion.Euler(0, 90, 0);
    //             break;
    //         case "Left":
    //             parent.position = new Vector3(-2.51f, -2, -2);
    //             parent.rotation = Quaternion.Euler(0, -90, 0);
    //             break;
    //     }
    // }

    // private void generateGridWithParentInDictionary(Transform parent, Dictionary<Vector2, Tile> dictionary)
    // {
    //     for (int x = 0; x < width; x++)
    //         for (int y = 0; y < height; y++)
    //         {
    //             Tile randomTile = Random.Range(0, 6) == 3 ? mountainTile : grassTile;
    //             Tile spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity, parent);
    //
    //             spawnedTile.name = $"Tile {x} {y}";
    //             spawnedTile.Init(x, y);
    //
    //             dictionary[new Vector2(x, y)] = spawnedTile;
    //         }
    // }
    
    public Tile getHeroSpawnTile()
    {
        return actualFaceState.getHeroSpawnTile();
    }
    
    public Tile getTileAtPosition(Vector2 pos)
    {
        return actualFaceState.getTileAtPosition(pos);
    }

    public Vector2 getPositionOfTile(Tile tile)
    {
        return actualFaceState.getPositionOfTile(tile);
    }

    protected Tile getHeroSpawnTile(Dictionary<Vector2, Tile> tiles)
    {
        return tiles.Where(t => t.Key.x < width / 2f && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    protected Tile getTileAtPosition(Vector2 pos, Dictionary<Vector2, Tile> tiles)
    {
        return tiles.TryGetValue(pos, out Tile tile)
            ? tile
            : null;
    }

    protected Vector2 getPositionOfTile(Tile tile, Dictionary<Vector2, Tile> tiles)
    {
        return tiles.First(t => t.Value.Equals(tile)).Key;
    }
}