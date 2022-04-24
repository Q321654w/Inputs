using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class MouseButtonUp : IKey
    {
        private readonly int _mouseButton;

        public MouseButtonUp(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool HasInput()
        {
            return Input.GetMouseButtonUp(_mouseButton);
        }
    }
}