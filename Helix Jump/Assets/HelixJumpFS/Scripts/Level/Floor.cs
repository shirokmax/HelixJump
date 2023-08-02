using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> defaultSegments;

    public void AddEmptySegments(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            defaultSegments[i].SetEmpty();
        }

        for (int i = amount - 1; i >= 0; i--)
        {
            defaultSegments.RemoveAt(i);
        }
    }

    public void AddRandomTrapSegments(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, defaultSegments.Count);

            defaultSegments[randomIndex].SetTrap();
            defaultSegments.RemoveAt(randomIndex);
        }
    }

    public void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void SetFinishFloor()
    {
        for (int i = 0; i < defaultSegments.Count; i++)
        {
            defaultSegments[i].SetFinish();
        }
    }
}
