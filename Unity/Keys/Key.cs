using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class Key : IKey
    {
        private readonly KeyCode _keyCode;

        public Key(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }

        public bool HasInput()
        {
            return Input.GetKey(_keyCode);
        }
    }
}