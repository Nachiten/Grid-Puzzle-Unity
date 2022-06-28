using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FaceManager : MonoBehaviour
{
    // This class is NOT instantiated in game
    
    private Transform parent;

    private Vector3 parentPosition;
    private Quaternion parentRotation;

    protected FaceManager topNeighbor;
    protected FaceManager bottomNeighbor;
    protected FaceManager leftNeighbor;
    protected FaceManager rightNeighbor;

    // ReSharper disable once MemberCanBePrivate.Global
    protected Dictionary<Vector2, Tile> tiles;

    private GameObject map;

    // [HideInInspector]
    public bool currentFace;

    protected void doAwake(string faceName, Vector3 newParentPosition, Quaternion newParentRotation)
    {
        parent = GameObject.Find("Tiles " + faceName)?.transform;
        tiles = new Dictionary<Vector2, Tile>();
        map = GameObject.Find("Map");
        
        Assert.IsNotNull(parent);
        Assert.IsNotNull(tiles);
        Assert.IsNotNull(map);
        
        parentPosition = newParentPosition;
        parentRotation = newParentRotation;
    }

    public void generateGrid()
    {
        GridManager.Instance.generateParticularGrid(parent, parentPosition, parentRotation, ref tiles);
    }

    public void printTiles()
    {
        foreach (KeyValuePair<Vector2, Tile> tile in tiles)
        {
            Debug.Log(tile.Value.name);
        }
    }

    public Tile getHeroSpawnTile()
    {
        return GridManager.Instance.getHeroSpawnTile(tiles);

    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public Tile getTileAtPosition(Vector3 pos)
    {
        Debug.Log("Getting tile at: " + pos);
        
        int tileWidth = GridManager.Instance.tileWidth;

        int maxHeight = (int)Math.Floor(GridManager.Instance.height * tileWidth / 2f);
        int minHeight = maxHeight * -1;
        
        int maxWidth = (int)Math.Floor(GridManager.Instance.width / 2f);
        int minWidth = maxWidth * -1;

        // Debug.Log("maxHeight: " + maxHeight);
        // Debug.Log("minHeight: " + minHeight);
        // Debug.Log("maxWidth: " + maxWidth);
        // Debug.Log("minWidth: " + minWidth);

        // TODO - NEIGHBORS CHANGE DEPENDING ON FACE ROTATION
        if (currentFace)
        { 
            if (pos.y > maxHeight)
            {
                Debug.Log("Out of bounds on Y+");
                    
                Tile tileFound = topNeighbor.getTileAtPosition(pos + new Vector3(0, -0.49f, 0.51f));
                Debug.Log("Tile found: " + tileFound);
            
                if (tileFound)
                {
                    map.transform.Rotate(new Vector3(-90, 0, 0));
                    GridManager.Instance.setNewFaceState(topNeighbor);
            
                    return tileFound;
                }
            }
                
            else if (pos.y < minHeight)
            {
                Debug.Log("Out of bounds on Y-");
                    
                Tile tileFound = bottomNeighbor.getTileAtPosition(pos + new Vector3(0, 0.49f, 0.51f));
                Debug.Log("Tile found: " + tileFound);
            
                if (tileFound)
                {
                    map.transform.Rotate(new Vector3(90, 0, 0));
                    GridManager.Instance.setNewFaceState(bottomNeighbor);
            
                    return tileFound;
                }
            }
            
            else if (pos.x > maxWidth)
            {
                Debug.Log("Out of bounds on X+");
                    
                Tile tileFound = rightNeighbor.getTileAtPosition(pos + new Vector3(-0.49f, 0, 0.51f));
                Debug.Log("Tile found: " + tileFound);
            
                if (tileFound)
                {
                    map.transform.Rotate(new Vector3(0, 90, 0));
                    GridManager.Instance.setNewFaceState(rightNeighbor);
            
                    return tileFound;
                }
            }
                
            else if (pos.x < minWidth)
            {
                Debug.Log("Out of bounds on X-");
                    
                Tile tileFound = leftNeighbor.getTileAtPosition(pos + new Vector3(0.49f, 0, 0.51f));
                Debug.Log("Tile found: " + tileFound);
            
                if (tileFound)
                {
                    map.transform.Rotate(new Vector3(0, -90, 0));
                    GridManager.Instance.setNewFaceState(leftNeighbor);
            
                    return tileFound;
                }
            }
        }
        
        return GridManager.Instance.getTileAtPosition(pos, tiles);
    }

    // public Vector2 getGlobalPositionOfTile(Tile tile)
    // {
    //     return GridManager.Instance.getGlobalPositionOfTile(tile, tiles);
    // }
}