using UnityEngine;

namespace Assets.Scrips
{
    public class Resource : MonoBehaviour
    {
        private bool _isAssembled = false;
        private bool _isFound = false;

        public bool IsAssembled => _isAssembled;
        public bool IsFound => _isFound;

        public void CollectResource() =>
            _isAssembled = true;

        public void ActivateResource() =>
            _isFound = true;
    }
}