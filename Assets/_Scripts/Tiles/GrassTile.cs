using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] protected Material material;
    [SerializeField] private Color _baseColor, _offsetColor;

    public override void Init(int x, int y)
    {
        bool isOffset = (x + y) % 2 == 1;

        material.color = isOffset ? _offsetColor : _baseColor;
    }
}