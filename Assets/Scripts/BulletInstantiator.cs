using System.Collections;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    [SerializeField] private Mover _prefab;
    [SerializeField] private TargetCollector _objectWithPoints;

    private float _timeWaitShooting = 3;
    private WaitForSeconds _wait;
    
    private void Start()
    {
        _wait = new WaitForSeconds(_timeWaitShooting);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (enabled)
        {
            var newBullet = Instantiate(_prefab, transform.position, Quaternion.identity);
            newBullet.Initialize(_objectWithPoints);

            yield return _wait;
        }
    }
}
