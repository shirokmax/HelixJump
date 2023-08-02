using UnityEngine;

public class FloorBreak : BallEvents
{
    protected override void OnBallCollisionSegment(SegmentType type, Collider other)
    {
        if (type == SegmentType.Empty)
        {
            GameObject floor = other.transform.parent.gameObject;

            // Удаление всех коллайдеров этажа во избежание лишних триггеров во время анимации
            for (int i = 0; i < floor.transform.childCount; i++)
            {
                Destroy(floor.transform.GetChild(i).GetComponent<MeshCollider>());
            }

            floor.GetComponent<Animator>().enabled = true;
            Destroy(floor, 0.7f);
        }
    }
}
