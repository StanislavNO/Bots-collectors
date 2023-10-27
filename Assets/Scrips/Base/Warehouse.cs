using System.Collections;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scrips
{
    public class Warehouse : MonoBehaviour
    {
        [SerializeField] private UnityEvent _resourceDelivered;

        public int Resource { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                _resourceDelivered.Invoke();

                AddResource();
                Destroy(resource.gameObject);
            }
        }

        public void DeleteResource(int value)
        {
            int minResource = 0;

            if (Resource > minResource)
                Resource -= value;
        }

        private void AddResource() => Resource++;
    }
}