using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class MouseButton : IKey
    {
        private readonly int _mouseButton;

        public MouseButton(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool HasInput()
        {
            return Input.GetMouseButton(_mouseButton);
        }
    }
}