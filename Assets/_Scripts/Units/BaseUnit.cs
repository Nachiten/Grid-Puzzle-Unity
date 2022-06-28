using System;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;

    protected void move(Direction direction, int distance)
    {
        Vector3 previousTilePosition = OccupiedTile.transform.position;

        switch (direction)
        {
            case Direction.Up:
                previousTilePosition.y += distance;
                break;
            case Direction.Down:
                previousTilePosition.y -= distance;
                break;
            case Direction.Left:
                previousTilePosition.x -= distance;
                break;
            case Direction.Right:
                previousTilePosition.x += distance;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        // Aca tiene que llegar la celda a donde me voy a mover
        Tile newTile = GridManager.Instance.getTileAtPosition(previousTilePosition);

        if (!newTile || !newTile.Walkable)
            return;

        newTile.SetUnit(this);
    }
}