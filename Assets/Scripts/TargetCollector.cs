using UnityEngine;
using System.Collections.Generic;

public class TargetCollector : MonoBehaviour
{
    public List<Transform> TargetPoints { get; private set; } = new List<Transform>();

    private void Awake()
    {
        RefreshChildArray();
    }

    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;

        if(pointCount > 0 )
        {
            for (int i = 0; i < pointCount; i++)
            {
                TargetPoints.Add(transform.GetChild(i));
            }
        }
        else
        {
            Debug.Log("Отсутствует таргет.");
        }
    }
}
