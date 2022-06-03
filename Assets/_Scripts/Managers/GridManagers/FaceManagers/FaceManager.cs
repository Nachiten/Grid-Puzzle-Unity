using System.Collections.Generic;
using UnityEngine;

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

    protected void doAwake(string faceName, Vector3 newParentPosition, Quaternion newParentRotation)
    {
        parent = GameObject.Find("Tiles " + faceName).transform;
        tiles = new Dictionary<Vector2, Tile>();
        
        map = GameObject.Find("Map");

        parentPosition = newParentPosition;
        parentRotation = newParentRotation;
    }

    public void generateGrid()
    {
        GridManager.Instance.generateParticularGrid(parent, parentPosition, parentRotation, ref tiles);
    }

    public Tile getHeroSpawnTile()
    {
        return GridManager.Instance.getHeroSpawnTile(tiles);
    }

    public Tile getTileAtPosition(Vector2 pos)
    {
        int height = GridManager.Instance.height;
        int width = GridManager.Instance.width;

        if (pos.y >= height)
        {
            Tile tileFound = topNeighbor.getTileAtPosition(pos - new Vector2(0, height));

            if (tileFound && tileFound.Walkable)
            {
                map.transform.Rotate(new Vector3(-90, 0, 0));
                GridManager.Instance.setNewFaceState(topNeighbor);

                return tileFound;
            }
            
        }
        
        if (pos.y < 0)
        {
            Tile tileFound = bottomNeighbor.getTileAtPosition(pos + new Vector2(0, height));

            if (tileFound && tileFound.Walkable)
            {
                map.transform.Rotate(new Vector3(90, 0, 0));
                GridManager.Instance.setNewFaceState(bottomNeighbor);

                return tileFound;
            }
        }

        if (pos.x >= width)
        {
            Tile tileFound = rightNeighbor.getTileAtPosition(pos - new Vector2(width, 0));

            if (tileFound && tileFound.Walkable)
            {
                map.transform.Rotate(new Vector3(0, 90, 0));
                GridManager.Instance.setNewFaceState(rightNeighbor);

                return tileFound;
            }
        }

        if (pos.x < 0)
        {
            Tile tileFound = leftNeighbor.getTileAtPosition(pos + new Vector2(width, 0));
            
            if (tileFound && tileFound.Walkable)
            {
                map.transform.Rotate(new Vector3(0, -90, 0));
                GridManager.Instance.setNewFaceState(leftNeighbor);

                return tileFound;
            }
        }
        
        return GridManager.Instance.getTileAtPosition(pos, tiles);
    }

    public Vector2 getPositionOfTile(Tile tile)
    {
        return GridManager.Instance.getPositionOfTile(tile, tiles);
    }
}