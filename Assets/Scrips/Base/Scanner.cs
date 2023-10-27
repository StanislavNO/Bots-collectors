using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scrips
{
    public class Scanner : MonoBehaviour
    {
        private const string TagResource = "Resource";

        private List<Transform> _resources = new();

        public List<Transform> ScanPositionResources()
        {
            FindResources();

            return _resources;
        }

        private void FindResources()
        {
            var resources = GameObject.FindGameObjectsWithTag(TagResource);

            foreach(var resource in resources)
            {
                if (resource.GetComponent<Resource>().IsAssembled == false)
                {
                    _resources.Add(resource.transform);
                }
            }
        }
    }
}