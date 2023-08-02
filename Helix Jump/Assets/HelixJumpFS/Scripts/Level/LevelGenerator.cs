using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("Settings")]
    [SerializeField] private int startFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int emptySegmentsAmount;
    [SerializeField] private int minTrapSegmentsAmount;
    [SerializeField] private int maxTrapSegmentsAmount;

    private int floorAmount;
    public int FloorAmount => floorAmount;

    private float lastFloorY;
    public float LastFloorY => lastFloorY;

    public void Generate(int level)
    {
        ClearFloors();

        floorAmount = startFloorAmount + level;

        axis.localScale = new Vector3(axis.localScale.x, floorAmount * floorHeight + floorHeight, axis.localScale.z);

        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, floorHeight * i, 0);
            floor.name = "Floor " + i;

            if (i == 0)
            {
                floor.SetFinishFloor();
            }

            if (i > 0 && i < floorAmount - 1)
            {
                floor.SetRandomRotation();
                floor.AddEmptySegments(emptySegmentsAmount);
                floor.AddRandomTrapSegments(Random.Range(minTrapSegmentsAmount, maxTrapSegmentsAmount + 1));
            }

            if (i == floorAmount - 1)
            {
                floor.AddEmptySegments(emptySegmentsAmount);

                lastFloorY = floor.transform.position.y;
            }
        }
    }

    public void ClearFloors()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
