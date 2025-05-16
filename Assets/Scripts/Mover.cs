using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private TargetCollector _objectWithPoints;
    private List<Transform> _spawnPoints = new List<Transform>();
    private Transform _currentTarget;
    private int _currentTargetIndex = 0;

    private void Start()
    {   
        if (_objectWithPoints.TargetPoints.Count > 0)
        {
            foreach (var target in _objectWithPoints.TargetPoints)
            {
                _spawnPoints.Add(target);
            }

            _currentTarget = _spawnPoints[_currentTargetIndex];
        }
    }

    private void Update()
    {
        if(_currentTarget != null)
        {
            Move();
        }
    }

    public void Initialize(TargetCollector points)
    {
        _objectWithPoints = points;
    }

    private void Move()
    {
        float _distanceToTarget = 0.5f;

        if (transform.position.IsEnoughClose(_currentTarget.position, _distanceToTarget))
        {
            _currentTargetIndex++;
            _currentTarget = GetNextPoint(_currentTargetIndex);
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    private Transform GetNextPoint(int targetIndex)
    {
        int _minTargetIndex = 0;

        if (targetIndex >= _spawnPoints.Count)
        {
            _currentTargetIndex = _minTargetIndex;
        }

        return _spawnPoints[_currentTargetIndex];
    }
}
