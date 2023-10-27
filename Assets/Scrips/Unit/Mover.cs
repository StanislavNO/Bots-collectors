using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector3 _startPosition;
        private List<Transform> _exitPoints;
        private List<Transform> _entryPoints;

        private Transform _target;
        private int _startCurrentPoint = 0;
        private int _currentPoint;

        private bool _isWorking;

        private void Awake()
        {
            _isWorking = false;
        }

        private void Start()
        {
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_target != null)
            {
                //Debug.Log("туда");
                _isWorking = true;
                Move(_exitPoints);
                //Debug.Log(_exitPoints.Count);

            }

            if (_target == null && _isWorking == true)
            {
                //Debug.Log("обратно");
                //Debug.Log(_target == null);
                //Debug.Log(_isWorking);

                Move(_entryPoints);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Warehouse _))
            {
                transform.position = _startPosition;
                _currentPoint = _startCurrentPoint;
            }
        }

        public void Init(Transform pathExit, Transform pathEntry)
        {
            //Debug.Log("init");

            _exitPoints = GetWaypoints(pathExit);
            _entryPoints = GetWaypoints(pathEntry);
        }

        public void SetTarget(Transform position)
        {
            //Debug.Log("settarget");
            _target = position;
            _exitPoints.Add(_target);
        }

        public void ComeBack()
        {
            //Debug.Log("combek");

            _exitPoints.Remove(_target);
            //Debug.Log(_exitPoints.Count + "remove");

            _currentPoint = _startCurrentPoint;
            _target = null;
        }

        public void FinishWorking()
        {
            _isWorking = false;
            //Debug.Log(_isWorking);
        }

        //public void GoToParking()
        //{
        //    transform.position = _startPosition;
        //    _currentPoint = _startCurrentPoint;
        //}

        private void Move(List<Transform> path)
        {
            //Debug.Log("move");

            if (_currentPoint < path.Count)
            {
                //Debug.Log(_currentPoint);
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
            //Debug.Log("getwaypoints");

            List<Transform> result = new();

            for (int i = 0; i < path.childCount; i++)
            {
                result.Add(path.GetChild(i));
            }

            return result;
        }
    }
}