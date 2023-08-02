using System.Collections.Generic;
using UnityEngine;

public class RandomColors : MonoBehaviour
{
    [Header("Материалы")]
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Material axisMaterial;
    [SerializeField] private Material defaulSegmentMaterial;
    [SerializeField] private Material finishSegmentMaterial;
    [SerializeField] private Material trapSegmentMaterial;

    [Header("Цвета")]
    [SerializeField] private List<Color> ballColors;
    [SerializeField] private List<Color> axisColors;
    [SerializeField] private List<Color> defaultSegmentColors;
    [SerializeField] private List<Color> finishSegmentColors;
    [SerializeField] private List<Color> trapSegmentColors;

    private void Start()
    {
        ballMaterial.color = ballColors[Random.Range(0, ballColors.Count)];
        axisMaterial.color = axisColors[Random.Range(0, axisColors.Count)];
        defaulSegmentMaterial.color = defaultSegmentColors[Random.Range(0, defaultSegmentColors.Count)];
        finishSegmentMaterial.color = finishSegmentColors[Random.Range(0, finishSegmentColors.Count)];
        trapSegmentMaterial.color = trapSegmentColors[Random.Range(0, trapSegmentColors.Count)];
    }
}
