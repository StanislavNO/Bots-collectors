using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scrips
{
    [RequireComponent(typeof(Collider))]
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private UnityEvent _resourcePickedUp;
        [SerializeField] private int distance;

        private bool _isWorking;
        private Transform _resource;
        private Transform _targetResource;

        private void Update()
        {
            if (_isWorking && _resource != null)
            {
                _resource.position = transform.position + Vector3.forward * distance;
            }
            else if (_isWorking && _resource == null)
            {
                _isWorking = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                //Debug.Log(resource.IsAssembled);
                if (resource.transform == _targetResource)
                {
                    Debug.Log("asd");
                    resource.CollectResource();

                    _resource = resource.transform;
                    _isWorking = true;
                    _resourcePickedUp.Invoke();
                }
            }
        }

        public void SetTargetResource(Transform resource)
        {
            _targetResource = resource;
        }
    }
}