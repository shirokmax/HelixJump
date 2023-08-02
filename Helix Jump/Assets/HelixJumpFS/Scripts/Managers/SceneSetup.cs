using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private LevelProgress levelProgress;

    private void Awake()
    {
        levelGenerator.Generate(levelProgress.CurrentLevel);

        ballController.transform.position = new Vector3(ballController.transform.position.x, levelGenerator.LastFloorY, ballController.transform.position.z);
    }
}
