using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scrips
{
    public class TargetMover : MonoBehaviour
    {
        private Transform _target;

        private void OnValidate()
        {
            Move();
        }

        public void SetTarget(Transform position)
        {
            _target = position;
        }

        private void Move()
        {
            transform.DOMove(_target.position, 5f);
        }
    }
}