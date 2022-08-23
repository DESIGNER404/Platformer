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
        private bool _isGrounded;
        private bool _allowDoubleJump;

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

        private void Update()
        {
            _isGrounded = IsGrounded();
        }

        // метод FixedUpdate() используется для физики (физического перемещения)
        private void FixedUpdate()
        {
            var xVelocity = _directionHorizontal * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            

            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRunning, _directionHorizontal != 0);

            UpdateSpriteDerection();
        }

        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpingPressing = _directionVertical > 0;

            if (_isGrounded) _allowDoubleJump = true;
            if (isJumpingPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
                
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
            }

            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling) return yVelocity;

            if (_isGrounded)
            {
                yVelocity += _jumpSpeed;
            } else if (_allowDoubleJump)
            {
                yVelocity = _jumpSpeed;
                _allowDoubleJump = false;
            }

            return yVelocity;
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
            Debug.Log("gggg");
        }
    }

}

