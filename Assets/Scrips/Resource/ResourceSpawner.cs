using UnityEngine;

namespace Assets.Scrips
{
    public class ResourceSpawner : MonoBehaviour
    {
        [SerializeField] private Resource _prefab;

        public void CreatePrefab(Vector3 position)
        {
            Instantiate(
                _prefab, 
                position + Vector3.up, 
                Quaternion.identity);

            ResourceWorldCounter.AddResource();
        }
    }
}