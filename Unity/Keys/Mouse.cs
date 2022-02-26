using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class Mouse : IKey
    {
        private readonly int _mouseButton;

        public Mouse(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool Execute()
        {
            return Input.GetMouseButton(_mouseButton);
        }
    }
}