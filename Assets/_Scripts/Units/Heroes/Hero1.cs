using UnityEngine;

public class Hero1 : BaseHero
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) move(Direction.Up, 1);

        if (Input.GetKeyDown(KeyCode.DownArrow)) move(Direction.Down, 1);

        if (Input.GetKeyDown(KeyCode.LeftArrow)) move(Direction.Left, 1);

        if (Input.GetKeyDown(KeyCode.RightArrow)) move(Direction.Right, 1);
    }
}