using UnityEngine;

public class FrontGridManager : FaceManager
{
    private const string faceName = "Front";
    public static FrontGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(-2, -2, -2.51f), Quaternion.Euler(0, 0, 0));
    }

    private void Start()
    {
        topNeighbor = TopGridManager.Instance;
        bottomNeighbor = BottomGridManager.Instance;
        leftNeighbor = LeftGridManager.Instance;
        rightNeighbor = RightGridManager.Instance;
    }
}