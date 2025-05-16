using UnityEngine;
using System.Collections.Generic;

public class TargetCollector : MonoBehaviour
{
    public List<Transform> TargetPoints { get; private set; } = new List<Transform>();

    private void Awake()
    {
        int pointCount = transform.childCount;
        Debug.Log(pointCount);

        if (pointCount == 0)
        {
            throw new System.Exception("Пустой список целей.");
        }

        for (int i = 0; i < pointCount; i++)
        {
            TargetPoints.Add(transform.GetChild(i));
        }
    }
}
