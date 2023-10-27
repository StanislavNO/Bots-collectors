using UnityEngine;

namespace Assets.Scrips
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private Mover _prefab;
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

            unit.Init(_pathExit, _pathEntry);
        }
    }
}