using UnityEngine;

public class InputManager : BallEvents
{
    [SerializeField] private MouseRotator mouseRotator;

    protected override void OnBallCollisionSegment(SegmentType type, Collider collider)
    {
        if (type == SegmentType.Trap || type == SegmentType.Finish)
        {
            mouseRotator.enabled = false;
        }
    }
}
