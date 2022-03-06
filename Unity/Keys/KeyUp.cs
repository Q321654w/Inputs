using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class KeyUp : IKey
    {
        private readonly KeyCode _keyCode;

        public KeyUp(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }

        public bool Evaluate()
        {
            return Input.GetKeyUp(_keyCode);
        }
    }
}