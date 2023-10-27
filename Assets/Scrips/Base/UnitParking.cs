using System.Collections;
using UnityEngine;

namespace Assets.Scrips
{
    [RequireComponent(typeof(Collider))]
    public class UnitParking : MonoBehaviour
    {
        public int Unit { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collector collector))
            {
                Unit++;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Collector collector))
            {
                Unit--;
            }
        }
    }
}