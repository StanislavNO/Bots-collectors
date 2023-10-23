using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scrips
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField] private UnityEvent<List<Transform>> _scanWasCompleted;

        private GameObject[] _resources;

        public void ScanPositionResources()
        {
            List<Transform> result = new List<Transform>();

            FindResources();

            foreach(var resource in _resources)
            {
                result.Add(resource.transform);
            }

            _scanWasCompleted.Invoke(result);
        }

        private void FindResources()
        {
            _resources = GameObject.FindGameObjectsWithTag("Resource");
        }
    }
}