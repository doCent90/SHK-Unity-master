using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3 _target;

    private const int Speed = 2;
    private const int RangeCircle = 4;

    private void Start()
    {
        SetRandomCirle();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Speed * Time.deltaTime);

        if (transform.position == _target)
            SetRandomCirle();
    }

    private void SetRandomCirle()
    {
        Vector3 randomCircleRange = Random.insideUnitCircle * RangeCircle;

        _target = randomCircleRange;
    }
}
