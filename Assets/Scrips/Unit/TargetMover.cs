using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scrips
{
    public class TargetMover : MonoBehaviour
    {
        private Transform _target;

        public bool IsWorking {  get; private set; }


        [SerializeField] private List<Transform> _path;

        private int _currentPoint;

        private Transform _startPosition;
        private Tween _tween;

        //private Sequence _sequence;
        //private bool _canRotation;
        //private bool _canMove;

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.)
        //}

        //private void Awake()
        //{
        //    _startPosition = transform.position;
        //}

        //private void Start()
        //{
        //    _path.Insert(0, _startPosition);
        //}

        private void Awake()
        {
            IsWorking = false;
        }

        private void Update()
        {
            if (_target != null)
            {
                IsWorking = true;
                Move();
            }
        }

        public void SetTarget(Transform position)
        {
            _target = position;
            _path.Add(_target);
        }


        private void Move()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                _path[_currentPoint].position, 
                10 * Time.deltaTime);

            if (transform.position == _path[_currentPoint].position &&
                _currentPoint < _path.Count -1) 
                _currentPoint++;
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent<Resource>(out Resource resource))
        //    {
        //        _tween.Kill();
        //        _path.Reverse();
        //        SetTarget(_startPosition);
        //    }
        //}

        //private void Update()
        //{

        //}

        private void GoToTarget()
        {
            float _timeRotation = 1.5f;
            float _speed = 15f;

            //_sequence = DOTween.Sequence();

            //_sequence.Append(transform.DOLookAt(_target.position, _speedRotation));

            //_sequence.Append(transform.DOMove(_target.position, 5f));

            //_sequence.PrependInterval(1);

            //_sequence.SetSpeedBased().SetEase(Ease.Linear)/*.SetSpeedBased()*/;

            //transform.DOLookAt(_target.position, _timeRotation)
            //    .SetEase(Ease.Linear);

            //transform.DOMove(_target.position, _speed)
            //    .SetSpeedBased().
            //    SetEase(Ease.Linear);

            //float timer = 5;
            //float count = 0;

            //do
            //{
            //    transform.LookAt(_target);

            //} while (timer > count);
        }

        private void qwe()
        {
            //_path.AddRange();
            //Vector3[] path = new Vector3[_path.Count];

            //for (int i = 0; i < path.Length; i++)
            //{
            //    path[i] = _path[i].position;
            //}

            //_tween = transform.DOPath(path, 10f, PathType.CatmullRom)
            //    .SetEase(Ease.Linear)
            //    .SetLookAt(0.01f);
                //.From(true);
                //.SetLoops(2, LoopType.Yoyo);

        }

        
    }
}