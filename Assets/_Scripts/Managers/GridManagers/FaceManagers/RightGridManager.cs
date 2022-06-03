using UnityEngine;

public class RightGridManager : FaceManager
{
    private const string faceName = "Right";
    public static RightGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(2.51f, -2, -2), Quaternion.Euler(0, -90, 0));
    }

    private void Start()
    {
        topNeighbor = TopGridManager.Instance;
        bottomNeighbor = BottomGridManager.Instance;
        leftNeighbor = FrontGridManager.Instance;
        rightNeighbor = BackGridManager.Instance;
    }
}