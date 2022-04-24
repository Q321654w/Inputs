using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class KeyDown : IKey
    {
        private readonly KeyCode _keyCode;

        public KeyDown(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }

        public bool HasInput()
        {
            return Input.GetKeyDown(_keyCode);
        }
    }
}