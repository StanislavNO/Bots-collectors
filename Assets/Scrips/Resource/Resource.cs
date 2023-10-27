using UnityEngine;

namespace Assets.Scrips
{
    public class Resource : MonoBehaviour
    {
        private bool _isAssembled = false;

        public bool IsAssembled => _isAssembled; 

        public void CollectResource()
        {
            _isAssembled = true;
            Debug.Log(IsAssembled);
        }
    }
}