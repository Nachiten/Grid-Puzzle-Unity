using UnityEngine;

public class Player : BaseUnit
{
    private int tileWdith;

    private void Start()
    {
        tileWdith = GridManager.Instance.tileWidth;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) move(Direction.Up, tileWdith);

        if (Input.GetKeyDown(KeyCode.DownArrow)) move(Direction.Down, tileWdith);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) move(Direction.Left, tileWdith);

        if (Input.GetKeyDown(KeyCode.RightArrow)) move(Direction.Right, tileWdith);
    }
}