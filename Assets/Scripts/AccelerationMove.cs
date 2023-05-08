using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove : IMove
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;
        private readonly float _acceleration;
        

        public AccelerationMove(Rigidbody2D rigidbody, float speed, float acceleration)
        {
            _rigidbody = rigidbody;
            _speed = speed;
            _acceleration = acceleration;
        }

        public void Move(float x, float y, float deltaTime)
        {
            var direction = new Vector2(x, y).normalized;
            var force = direction * _speed * _acceleration * deltaTime;
            _rigidbody.AddForce(force);
        }
    }
}
