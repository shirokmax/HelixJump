using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] private BallController ballController;

    protected virtual void Awake()
    {
        ballController.CollisionSegment.AddListener(OnBallCollisionSegment);
    }

    protected virtual void OnDestroy()
    {
        ballController.CollisionSegment.RemoveListener(OnBallCollisionSegment);
    }

    //Events
    protected virtual void OnBallCollisionSegment(SegmentType type, Collider other) { }
}