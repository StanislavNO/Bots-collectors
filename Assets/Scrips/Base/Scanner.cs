using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    public class Scanner : MonoBehaviour
    {
        private List<Resource> _resources = new();

        public List<Resource> ScanPositionResources()
        {
            return GetInactiveResources();
        }

        public void AddRes(Resource resource)
        {
            _resources.Add(resource);
        }

        private List<Resource> GetInactiveResources()
        {
            List<Resource> inactiveResources = new();

            foreach (Resource resource in _resources)
            {
                if(resource.IsActive == false)
                    inactiveResources.Add(resource);
            }

            return inactiveResources;
        }
    }
}