using UnityEngine;
namespace Asteroids
{
    internal sealed class RotationShip : IRotation
    {
        private readonly Transform _transform;
        public RotationShip(Transform transform)
        {
            _transform = transform;
        }
        public void Rotation(Vector3 direction)
        {
            
            var angle = Mathf.Atan2(direction.y - _transform.position.y, direction.x - _transform.position.x) * Mathf.Rad2Deg;

            
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}