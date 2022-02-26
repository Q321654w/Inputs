using UnityEngine;

namespace Inputs.Unity.Keys
{
    public class MouseDown : IKey
    {
        private readonly int _mouseButton;

        public MouseDown(int mouseButton)
        {
            _mouseButton = mouseButton;
        }

        public bool Execute()
        {
            return Input.GetMouseButtonDown(_mouseButton);
        }
    }
}