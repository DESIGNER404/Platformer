using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;

        [SerializeField] private LayerCheck _groundCheck;

        private Rigidbody2D _rigidbody;

        private float _directionHorizontal, _directionVertical;

        //Импортируем компонент с коллаидер, который чекает землю
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
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
            if (isJumping)
            {
                if (IsGrounded())
                {
                    _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            
                
            }
            else if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }
        }

        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
        }

        public void SaySomething()
        {
            Debug.Log("Я могу говорить!!!");
        }
    }

}

