using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;

        [SerializeField] private LayerCheck _groundCheck;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _sprite;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int IsRunning = Animator.StringToHash("is-running");

        private float _directionHorizontal, _directionVertical;

        //Импортируем компонент с коллаидер, который чекает землю
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void SetDirectionHorizontal(float direction)
        {
            _directionHorizontal = direction;
        }

        public void SetDirectionVertical(float direction)
        {
            _directionVertical = direction;
        }

        // метод FixedUpdate() используется для физики (физического перемещения)
        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_directionHorizontal * _speed, _rigidbody.velocity.y);

            var isJumping = _directionVertical > 0;
            var isGrounded = IsGrounded();
            if (isJumping)
            {
                if (IsGrounded() && _rigidbody.velocity.y <= 0)
                {
                    _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            
                
            }
            else if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }

            _animator.SetBool(IsGroundKey, isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRunning, _directionHorizontal != 0);

            UpdateSpriteDerection();
        }

        private void UpdateSpriteDerection()
        {
            if (_directionHorizontal > 0)
            {
                _sprite.flipX = false;
            }
            else if (_directionHorizontal < 0)
            {
                _sprite.flipX = true;
            }
        }

        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
        }

        public void SaySomething()
        {
            Debug.Log("ХУЙ ПИЗДА ДЖИГУРДА");
        }
    }

}

