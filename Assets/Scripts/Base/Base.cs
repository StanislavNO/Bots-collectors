﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private Scanner _scanner;
        [SerializeField] private UnitParking _unitParking;

        private List<Resource> _resources = new();
        private float _turnOnTime = 1;

        public int ResourcesFound => _resources.Count;

        private void FixedUpdate()
        {
            if (_resources.Count > 0 && _unitParking.ParkedUnits > 0)
                StartCoroutine(EnableCollector());
        }

        public void ScanningMap() =>
            _resources = _scanner.ScanPositionResources();

        private bool TryGetInactiveResource(out Resource result)
        {
            foreach (Resource resource in _resources)
            {
                if (resource.IsFound == false && resource.IsAssembled == false)
                {
                    result = resource;
                    return true;
                }
            }

            result = null;
            return false;
        }

        private IEnumerator EnableCollector()
        {
            WaitForSecondsRealtime delay = new(_turnOnTime);

            if (TryGetInactiveResource(out Resource resource))
                _unitParking.SendingUnit(resource);

            yield return delay;
        }
    }
}