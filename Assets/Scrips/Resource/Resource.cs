using UnityEngine;

namespace Assets.Scrips
{
    public class Resource : MonoBehaviour
    {
        private bool _isAssembled = false;
        private bool _isActive = false;

        public bool IsAssembled => _isAssembled;
        public bool IsActive => _isActive;

        public void CollectResource()
        {
            _isAssembled = true;
        }

        public void ActivateResource()
        {
            _isActive = true;
        }
    }
}