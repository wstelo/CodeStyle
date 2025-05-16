using System.Collections;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    [SerializeField] private Mover _prefab;
    [SerializeField] private TargetCollector _objectWithPoints;

    private float _timeWaitShooting = 3;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_timeWaitShooting);

        while (enabled)
        {
            var newBullet = Instantiate(_prefab, transform.position, Quaternion.identity);
            newBullet.Initialize(_objectWithPoints);

            yield return wait;
        }
    }
}
