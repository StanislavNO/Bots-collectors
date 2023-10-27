using System.Collections;
using UnityEngine;

namespace Assets.Scrips
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] Transform resource;
        [SerializeField] Mover target;

        public bool IsWorking;

        private void Start()
        {
            target.SetTarget(resource);
            IsWorking = true;
        }


        //dfhddddddddddddddddddd

        
    }
}