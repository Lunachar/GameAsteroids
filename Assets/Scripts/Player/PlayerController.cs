using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerView _playerView;

        private void Awake()
        {
            _playerView = GetComponent<PlayerView>();
        }

        private void Start()
        {
             _playerView._rb = GetComponent<Rigidbody2D>();
             _playerView._collider = GetComponent<BoxCollider2D>();
        }



        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _playerView.Shoot();
            }
        }

        private void FixedUpdate()
        {
                var horizontalInput = Input.GetAxis("Horizontal");
                var verticalInput = Input.GetAxis("Vertical");
                _playerView._model.Move(horizontalInput, verticalInput);
        }
    }
}