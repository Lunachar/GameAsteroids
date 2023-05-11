using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController _controller;
        internal PlayerModel _model;
        
        private Transform _transform;
        internal Rigidbody2D _rb;
        internal BoxCollider2D _collider;
        
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _hp;
        [SerializeField] private float _speed;
        
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private GameObject _bulletPrefab;

        private void Awake()
        {
            _transform = gameObject.transform;
            _controller = GetComponent<PlayerController>();
            _model = new PlayerModel(_transform, _rb,_collider, _rotationSpeed, _hp, _speed, _bulletSpawnPoint, _bulletPrefab);
        }

        private void Update()
        {
            //_controller.Move();
        }

        public void Rotate(float rotationAngle)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
        }

        public void Shoot()
        {
            Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
        }
    }
}