using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] LevelProgress levelProgress;

    private int scores;
    public int Scores => scores;

    private int maxScores;
    public int MaxScores => maxScores;

    private bool isLastEmpty;
    private int emptyCounter;

    protected override void Awake()
    {
        base.Awake();

        maxScores = PlayerPrefs.GetInt("ScoresCollector:MaxScores", 0);
    }

    protected override void OnBallCollisionSegment(SegmentType type, Collider other)
    {
        if (type == SegmentType.Empty)
        {
            // ќчки умножаютс€ за каждое падение через пустой сегмент подр€д, чем больше подр€д - тем больше множитель
            if (isLastEmpty == true)
            {
                emptyCounter++;
                scores += levelProgress.CurrentLevel * emptyCounter;
            }

            scores += levelProgress.CurrentLevel;

            isLastEmpty = true;
        }
        else
        {
            isLastEmpty = false;
            emptyCounter = 0;
        }

        if (type == SegmentType.Finish && scores > maxScores)
        {
            maxScores = scores;
            PlayerPrefs.SetInt("ScoresCollector:MaxScores", maxScores);
        }
    }
}
