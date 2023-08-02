using UnityEngine;

public class BallSplash : BallEvents
{
    [SerializeField] private Transform level;
    [SerializeField] private Transform ballModel;
    [SerializeField] private GameObject ballSplash;
    [SerializeField] private Material ballMaterial;

    protected override void OnBallCollisionSegment(SegmentType type, Collider other)
    {
        if (type != SegmentType.Empty)
        {
            GameObject splash = Instantiate(ballSplash, 
                                            new Vector3(ballModel.position.x, ballModel.position.y - 0.1f, ballModel.position.z), 
                                            Quaternion.Euler(90, Random.Range(0, 360), 0), 
                                            other.transform.parent);

            splash.GetComponent<SpriteRenderer>().color = ballMaterial.color;
        }
    }
}
