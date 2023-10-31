using UnityEngine;

namespace Assets.Scrips
{
    [RequireComponent(typeof(TargetMover))]
    public class Collector : MonoBehaviour
    {
        [SerializeField] TargetMover _mover;
        [SerializeField] Inventory _inventory;

        public bool IsWorking => _mover.IsWorking; 

        public void SetTarget(Resource resource)
        {
            resource.ActivateResource();

            _mover.SetTarget(resource.transform);
            _inventory.SetTarget(resource);
        }
    }
}