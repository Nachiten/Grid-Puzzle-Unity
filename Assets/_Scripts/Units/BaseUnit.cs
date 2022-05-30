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
        Vector2 tilePosition = GridManager.Instance.getPositionOfTile(OccupiedTile);

        switch (direction)
        {
            case Direction.Up:
                tilePosition.y += distance;
                break;
            case Direction.Down:
                tilePosition.y -= distance;
                break;
            case Direction.Left:
                tilePosition.x -= distance;
                break;
            case Direction.Right:
                tilePosition.x += distance;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        Tile newTile = GridManager.Instance.getTileAtPosition(tilePosition);

        if (newTile == null)
            return;

        newTile.SetUnit(this);
    }
}