using UnityEngine;

namespace Assets.Scrips
{
    public class Warehouse : MonoBehaviour
    {
        [SerializeField] private Transform _storageBox;

        public int Resource { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Resource resource))
            {
                AddResource();
                CollectResource(resource);
            }
        }

        public void DeleteResource(int value)
        {
            int minResource = 0;

            if (Resource > minResource)
                Resource -= value;
        }

        private void AddResource() => Resource++;

        private void CollectResource(Resource resource)
        {
            resource.CollectResource();
            resource.transform.position = _storageBox.position;
        }
    }
}