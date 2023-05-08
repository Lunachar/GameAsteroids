using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float maxAngularSpeed;
        private Camera _camera;
        private Ship _ship;
        private Rigidbody2D _rb;
        private IRotation _rotation;
        private void Start()
        {
            _camera = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
            _rotation = new RotationShip(transform);
            //_ship = new Ship(_moveTransform, _rotation);
        }
        private void Update()
        {
            var direction = Input.mousePosition -
            _camera.WorldToScreenPoint(transform.position);
            _rb.AddForce(transform.up * _speed * Input.GetAxis("Vertical"));
            _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxAngularSpeed);
            _rb.AddTorque(-Input.GetAxis("Horizontal") * _acceleration);
            _rb.angularDrag = 2f;
            _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, -maxAngularSpeed, maxAngularSpeed);
            //_ship.Rotation(direction);
            //_ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
            //Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _speed += _acceleration;

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _speed -= _acceleration;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Instantiate(_bullet, _barrel.position,
                _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}