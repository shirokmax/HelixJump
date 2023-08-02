using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement ballMovement;

    [HideInInspector] public UnityEvent<SegmentType, Collider> CollisionSegment;

    private void Start()
    {
        ballMovement = GetComponent<BallMovement>();
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Segment>(out Segment segment) == true)
        {
            if (segment.Type == SegmentType.Empty)
            {
                ballMovement.Fall(other.transform.position.y);
            }

            if (segment.Type == SegmentType.Default)
            {
                ballMovement.Jump();
            }

            if (segment.Type == SegmentType.Trap || segment.Type == SegmentType.Finish)
            {
                ballMovement.Stop();
            }
        }

        CollisionSegment.Invoke(segment.Type, other);
    }
}
