using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{
    private int currentLevel;
    public int CurrentLevel => currentLevel;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif

    protected override void OnBallCollisionSegment(SegmentType type, Collider other)
    {
        if (type == SegmentType.Finish)
        {
            currentLevel++;
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:Level", currentLevel);
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgress:Level", 1);
    }

#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif

}

