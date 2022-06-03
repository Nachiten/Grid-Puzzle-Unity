using UnityEngine;

public class BottomGridManager : FaceManager
{
    private const string faceName = "Bottom";
    public static BottomGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(-2, -2.51f, 2), Quaternion.Euler(-90, 0, 0));
    }

    private void Start()
    {
        topNeighbor = FrontGridManager.Instance;
        bottomNeighbor = BackGridManager.Instance;
        leftNeighbor = LeftGridManager.Instance;
        rightNeighbor = RightGridManager.Instance;
    }
}