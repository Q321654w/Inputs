using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class MouseUp : IKey
    {
        private readonly int _mouseButton;

        public MouseUp(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool Execute()
        {
            return Input.GetMouseButtonUp(_mouseButton);
        }
    }
}