using System;
using UnityEngine;

namespace Inputs.Unity.Direction.Decorator
{
    public class ConstantClampDirection : DirectionDecorator<Vector2>
    {
        private readonly float _positive;
        private readonly float _negative;

        public ConstantClampDirection(IDirection<Vector2> child) : this(-1, 1, child)
        {
        }

        public ConstantClampDirection(float negative, float positive, IDirection<Vector2> child) : base(child)
        {
            _negative = negative;
            _positive = positive;
        }

        public override Vector2 Direction()
        {
            var value = Child.Direction();

            var x = Math.Min(Math.Max(value.x, _positive), _negative);
            var y = Math.Min(Math.Max(value.y, _positive), _negative);


            return new Vector2(x, y);
        }
    }
}