using System.Collections;
using UnityEngine;

namespace Assets.Scrips
{
    [RequireComponent(typeof(Mover))]
    public class Collector : MonoBehaviour
    {
        [SerializeField] Mover _mover;
        [SerializeField] Inventory _inventory;

        public void SetTarget(Transform resource)
        {
            _inventory.SetTargetResource(resource);
            _mover.SetTarget(resource);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.TryGetComponent(out UnitParking parking))
            {
                _mover.FinishWorking();
            }
        }

        //public void GoToBase()
        //{
        //    _mover.ComeBack();
        //}
    }
}