using UnityEngine;

namespace Inputs.Unity.Axis.Joysticks
{
    public class JoystickAxis : IAxis
    {
        private readonly string _axisName;

        public JoystickAxis(string axisName)
        {
            _axisName = axisName;
        }

        public float Value()
        {
            return Input.GetAxis(_axisName);
        }
    }
}