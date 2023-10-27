using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    public class Base : MonoBehaviour
    {
        [SerializeField] private Scanner _scanner;
        [SerializeField] private UnitParking _unitParking;

        private Stack<Transform> _resources = new();

        public int ResourcesFound => _resources.Count;
        
        private void Update()
        {
            if (_resources.Count > 0 && _unitParking.NumberUnits > 0)
            {
                _unitParking.SendingUnit(_resources.Pop());
            }
        }

        public void ScanningMap()
        {
            _resources = new(_scanner.ScanPositionResources());
        }
    }
}