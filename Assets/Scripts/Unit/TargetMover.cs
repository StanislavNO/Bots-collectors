using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scrips
{
    public class TargetMover : MonoBehaviour
    {
        [SerializeField] private UnityEvent _targetAchieved;

        [SerializeField] private float _speed;

        private Transform _target;
        private Vector3 _startPosition;

        private List<Transform> _exitPoints;
        private List<Transform> _entryPoints;
        private int _startCurrentPoint = 0;
        private int _currentPoint;

        private bool _isWorking = false;

        public bool IsWorking => _isWorking;

        public void Init(Transform pathExit, Transform pathEntry)
        {
            _exitPoints = GetWaypoints(pathExit);
            _entryPoints = GetWaypoints(pathEntry);
        }

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_target != null)
            {
                Move(_exitPoints);

                if (transform.position == _target.position)
                {
                    ComeBack();
                    _targetAchieved.Invoke();
                }
            }

            if (_target == null && _isWorking == true)
                Move(_entryPoints);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Warehouse _))
            {
                transform.position = _startPosition;
                _currentPoint = _startCurrentPoint;
                _isWorking = false;
            }
        }

        public void SetTarget(Transform resource)
        {
            _isWorking = true;
            _target = resource;

            _exitPoints.Add(_target);
        }

        public void ComeBack()
        {
            _exitPoints.Remove(_target);
            _target = null;

            _currentPoint = _startCurrentPoint;
        }

        private void Move(List<Transform> path)
        {
            if (_currentPoint < path.Count)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    path[_currentPoint].position,
                    _speed * Time.deltaTime);

                transform.LookAt(path[_currentPoint]);
            }

            if (transform.position == path[_currentPoint].position &&
                _currentPoint < path.Count - 1)
                _currentPoint++;
        }

        private List<Transform> GetWaypoints(Transform path)
        {
            List<Transform> result = new();

            for (int i = 0; i < path.childCount; i++)
            {
                result.Add(path.GetChild(i));
            }

            return result;
        }
    }
}