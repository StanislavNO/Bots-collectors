using System.Collections;
using UnityEngine;

namespace Assets.Scrips
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] Transform resource;
        [SerializeField] TargetMover target;
        private void Start()
        {
            target.SetTarget(resource);
        }
    }
}