using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Transform _objectWithPoints;
    private List<Transform> _spawnPoints = new List<Transform>();
    private Transform _currentTarget;
    private int _minTargetIndex = 0;
    private int _currentTargetIndex = 0;

    private void Start()
    {      
        for (int i = 0; i < _objectWithPoints.childCount; i++)
        {
            _spawnPoints.Add(_objectWithPoints.GetChild(i));
        }

        _currentTarget = _spawnPoints[_currentTargetIndex];
    }

    private void Update()
    {
        if (transform.position == _spawnPoints[_currentTargetIndex].position)
        {
            _currentTargetIndex++;
            _currentTarget = GetNextPoint(_currentTargetIndex);
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    public void Initialize(Transform points)
    {
        _objectWithPoints = points;
    }

    private Transform GetNextPoint(int targetIndex)
    {
        if (targetIndex >= _spawnPoints.Count)
        {
            _currentTargetIndex = _minTargetIndex;
        }

        return _spawnPoints[_currentTargetIndex];
    }
}
