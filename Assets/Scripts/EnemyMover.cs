using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Vector3[] _waypoints;
    private float _rangePatrol = 0.8f;
    private int _countWaypoints = 5;
    private int _currentWaypoint = 0;
    private int _speed;
    private int _minSpeed = 1;
    private int _maxSpeed = 4;

    private void Start()
    {
        _waypoints = new Vector3[_countWaypoints];
        AddWaypoint();
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint])
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
            _currentWaypoint = (++_currentWaypoint) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint], _speed * Time.deltaTime);
    }

    private void AddWaypoint()
    {
        int fullAngle = 360;
        int angleStep = fullAngle / _countWaypoints;

        for (int i = 0; i < _countWaypoints; i++)
        {
            _waypoints[i] = new Vector3(_rangePatrol * Mathf.Cos(angleStep * i * Mathf.Deg2Rad), _rangePatrol * Mathf.Sin(angleStep * i * Mathf.Deg2Rad)) + transform.position;
        }
    }
}