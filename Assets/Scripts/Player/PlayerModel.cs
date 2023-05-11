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
            //_transform.Translate(movement);
            
            //_playerView.Rotate(.GetRotationAngle());
        }

        // public float GetRotationAngle()
        // {
        //     Vector3 mousePosition = Input.mousePosition;
        //     Vector3 playerPosition = Camera.main.WorldToScreenPoint(_transform.position);
        //     Vector3 direction = mousePosition - playerPosition;
        //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //     return angle;
        // }

        // public void Shoot()
        // {
        //     
        // }
    }
}