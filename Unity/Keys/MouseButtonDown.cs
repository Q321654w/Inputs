using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class MouseButtonDown : IKey
    {
        private readonly int _mouseButton;

        public MouseButtonDown(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool HasInput()
        {
            return Input.GetMouseButtonDown(_mouseButton);
        }
    }
}