using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainTile : Tile
{
    public void Awake()
    {
        _isWalkable = false;
    }
}
