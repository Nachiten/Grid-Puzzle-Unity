using UnityEngine;

public class TopGridManager : FaceManager
{
    private const string faceName = "Top";
    public static TopGridManager Instance;

    private void Awake()
    {
        Instance = this;

        doAwake(faceName, new Vector3(-2, 2.51f, -2), Quaternion.Euler(90, 0, 0));
    }
    
    private void Start()
    {
        topNeighbor = BackGridManager.Instance;
        bottomNeighbor = FrontGridManager.Instance;
        leftNeighbor = LeftGridManager.Instance;
        rightNeighbor = RightGridManager.Instance;
    }
}