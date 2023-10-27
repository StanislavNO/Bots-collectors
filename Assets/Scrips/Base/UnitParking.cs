using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scrips
{
    [RequireComponent(typeof(Collider))]
    public class UnitParking : MonoBehaviour
    {
        [SerializeField] private UnityEvent CollectorArrived;

        private Stack<Collector>  collectors = new();

        public int NumberUnits => collectors.Count;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Collector collector))
            {
                collectors.Push(collector);
                //collector.GetComponent<Mover>().FinishWorking();
            }
        }

        public void SendingUnit(Transform resource)
        {
            int minUnits = 0;

            if (collectors.Count > minUnits)
            {
                var collector = collectors.Pop();

                collector.SetTarget(resource);
                //collector.GetComponent<Mover>().SetTarget(resource);
            }
        }
    }
}