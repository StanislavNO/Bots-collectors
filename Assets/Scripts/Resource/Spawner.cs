﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Assets.Scrips
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Resource> _resourceCreated;
        [SerializeField] private List<Resource> _resources;

        public void CreatePrefab(Vector3 position)
        {
            Resource resource = Instantiate(
                GetResource(),
                position + Vector3.up,
                Quaternion.identity);

            _resourceCreated.Invoke(resource);
            ResourceWorldCounter.AddResource();
        }

        private Resource GetResource() => 
            _resources[Random.Range(0, _resources.Count)];
    }
}