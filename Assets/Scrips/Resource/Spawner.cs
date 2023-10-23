using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scrips
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Resource> _resources;

        public void CreatePrefab(Vector3 position)
        {
            Instantiate(
                GetResource(),
                position + Vector3.up,
                Quaternion.identity);

            ResourceWorldCounter.AddResource();
        }

        private Resource GetResource() => 
            _resources[Random.Range(0, _resources.Count)];
    }
}