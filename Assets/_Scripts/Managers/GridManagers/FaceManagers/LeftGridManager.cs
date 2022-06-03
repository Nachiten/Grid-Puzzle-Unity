using UnityEngine;

public class LeftGridManager : FaceManager
{
    private const string faceName = "Left";
    public static LeftGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(-2.51f, -2, 2), Quaternion.Euler(0, 90, 0));
    }

    private void Start()
    {
        topNeighbor = TopGridManager.Instance;
        bottomNeighbor = BottomGridManager.Instance;
        leftNeighbor = BackGridManager.Instance;
        rightNeighbor = FrontGridManager.Instance;
    }
}