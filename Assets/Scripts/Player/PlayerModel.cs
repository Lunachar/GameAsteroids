using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        private Transform _transform;
        private Rigidbody2D _rb;
        private BoxCollider2D _collider;
        private float _rotationSpeed;
        private int _hp;
        private float _speed;
        private Transform _bulletSpawnPoint;
        private GameObject _bulletPrefab;
        private float _screenPadding = 0.1f;
       
        public PlayerModel(Transform transform, Rigidbody2D rb, BoxCollider2D boxCollider, float rotationSpeed, int hp,
            float moveSpeed, Transform bulletSpawnPoint, GameObject bulletPrefab)
        {
            _transform = transform;
            _rb = rb;
            _rotationSpeed = rotationSpeed;
            _hp = hp;
            _speed = moveSpeed;
            _bulletSpawnPoint = bulletSpawnPoint;
            _bulletPrefab = bulletPrefab;

        }

        internal void Move(float horizontalInput, float verticalInput)
        {
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            _rb.AddForce(movement * _speed, ForceMode2D.Impulse);
             float rotationAngle = GetRotationAngle();
             _transform.rotation = quaternion.Euler(0f, 0f, rotationAngle);

             float minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
             float maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
             float minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
             float maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

             float clampedX = Mathf.Clamp(_transform.position.x, minX, maxX);
             float clampedY = Mathf.Clamp(_transform.position.y, minY, maxY);

             _transform.position = new Vector3(clampedX, clampedY, _transform.position.z);

        }

        public float GetRotationAngle()
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 playerPosition = Camera.main.WorldToScreenPoint(_transform.position);
            Vector2 direction = mousePosition - playerPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg *_rotationSpeed;
            return angle;
        }

        // public void Shoot()
        // {
        //     
        // }
    }
}