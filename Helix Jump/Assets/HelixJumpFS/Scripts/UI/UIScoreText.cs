using TMPro;
using UnityEngine;

public class UIScoreText : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text maxScoreText;

    private void Start()
    {
        maxScoreText.text = "Рекорд: " + scoresCollector.MaxScores.ToString();
    }

    protected override void OnBallCollisionSegment(SegmentType type, Collider other)
    {
        if (type != SegmentType.Trap)
        {
            scoreText.text = scoresCollector.Scores.ToString();
        }
    }
}
