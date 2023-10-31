using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    public class Scanner : MonoBehaviour
    {
        private List<Resource> _resources = new();

        public List<Resource> ScanPositionResources() =>
            GetResourcesNotFound();

        public void AddResource(Resource resource) =>
            _resources.Add(resource);

        private List<Resource> GetResourcesNotFound()
        {
            List<Resource> resourcesNotFound = new();

            foreach (Resource resource in _resources)
            {
                if (resource.IsFound == false)
                    resourcesNotFound.Add(resource);
            }

            return resourcesNotFound;
        }
    }
}