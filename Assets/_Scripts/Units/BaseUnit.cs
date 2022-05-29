using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class BaseUnit : MonoBehaviour {
    public string UnitName;
    public Tile OccupiedTile;

    public void move(Direction direction, int distance)
    {
        Vector2 tilePosition = GridManager.Instance.GetPositionOfTile(this.OccupiedTile);

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
        }

        Tile newTile = GridManager.Instance.GetTileAtPosition(tilePosition);

        if (newTile == null)
            return;
        
        newTile.SetUnit(this);
    }
}
