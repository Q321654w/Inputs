using System.Collections.Generic;
using UnityEngine;

namespace Inputs.Common
{
    public class CustomCollider : MonoBehaviour
    {
        private List<Collision> _collisions;

        public void Initialize(int bufferSize)
        {
            _collisions = new List<Collision>(bufferSize);
        }

        public bool HasCollisions()
        {
            return _collisions.Count > 0;
        }

        public IReadOnlyCollection<Collision> ReadCollisions()
        {
            return _collisions;
        }

        private void OnCollisionEnter(Collision other)
        {
            _collisions.Add(other);
        }
        
        private void OnCollisionExit(Collision other)
        {
            var indexOfOther = _collisions.IndexOf(other);
            var latsIndex = _collisions.Count - 1;
            _collisions[indexOfOther] = _collisions[latsIndex];
            _collisions.RemoveAt(latsIndex);
        }
    }
}