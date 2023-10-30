using UnityEngine;

namespace Assets.Scrips
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitParking _unitParking;

        [SerializeField] private Collector _prefab;
        [SerializeField] private int _startNumber;

        [SerializeField] private Transform _pathExit;
        [SerializeField] private Transform _pathEntry;

        private void Start()
        {
            for (int i = 0; i < _startNumber; i++)
            {
                CreateUnit();
            }
        }

        public void CreateUnit()
        {
            var unit = Instantiate(
                _prefab, 
                transform.position, 
                Quaternion.identity);

            unit.GetComponent<TargetMover>().Init(_pathExit, _pathEntry);

            _unitParking.AddUnit(unit);
        }
    }
}