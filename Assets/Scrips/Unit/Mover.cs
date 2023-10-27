using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scrips
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _pathExit;
        [SerializeField] private Transform _pathEntry;

        private List<Transform> _exitPoints;
        private List<Transform> _entryPoints;

        private Transform _target;
        private int _currentPoint;

        private bool _isWorking;

        private void Awake()
        {
            _isWorking = false;

            _exitPoints = GetWaypoints(_pathExit);
            _entryPoints = GetWaypoints(_pathEntry);
        }

        private void Update()
        {
            if (_target != null)
            {
                _isWorking = true;
                Move(_exitPoints);
            }

            if (_target == null && _isWorking)
            {
                Move(_entryPoints);
            }
        }

        public void SetTarget(Transform position)
        {
            _target = position;
            _exitPoints.Add(_target);
        }

        public void ComeBack()
        {
            _exitPoints.RemoveAt(_exitPoints.IndexOf(_target));
            _currentPoint = 0;
            _target = null;
        }

        private void Move(List<Transform> path)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                path[_currentPoint].position,
                _speed * Time.deltaTime);

            transform.LookAt(path[_currentPoint]);

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