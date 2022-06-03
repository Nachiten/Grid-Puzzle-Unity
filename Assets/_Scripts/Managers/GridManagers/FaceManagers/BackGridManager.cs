using UnityEngine;

public class BackGridManager : FaceManager
{
    private const string faceName = "Back";
    public static BackGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(2, -2, 2.51f), Quaternion.Euler(0, 180, 0));
    }

    private void Start()
    {
        topNeighbor = TopGridManager.Instance;
        bottomNeighbor = BottomGridManager.Instance;
        leftNeighbor = RightGridManager.Instance;
        rightNeighbor = LeftGridManager.Instance;
    }
}