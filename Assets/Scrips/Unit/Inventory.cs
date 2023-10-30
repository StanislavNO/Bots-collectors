using UnityEngine;

namespace Assets.Scrips
{
    [RequireComponent(typeof(Collider))]
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int distance;

        private Resource _targetResource;
        private bool _isWorking;

        public bool IsWorking => _isWorking;

        private void Update()
        {
            if (_isWorking && _targetResource.IsAssembled == false)
            {
                TakeResource();
            }
            else if (_isWorking && _targetResource.IsAssembled == true)
            {
                _isWorking = false;
            }
        }

        public void SetTarget(Resource resource)
        {
            _targetResource = resource;
        }

        public void Working()
        {
            _isWorking = true;
        }

        private void TakeResource()
        {
            _targetResource.transform.position = transform.position + Vector3.forward * distance;
        }
    }
}