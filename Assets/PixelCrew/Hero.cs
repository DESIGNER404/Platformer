using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private float _directionHorizontal, _directionVertical;

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
            if (_directionHorizontal != 0)
            {
                var delta = _directionHorizontal * _speed * Time.deltaTime;
                var newXPosition = transform.position.x + delta;
                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            }
            else if (_directionVertical != 0)
            {
                var delta = _directionVertical * _speed * Time.deltaTime;
                var newYPosition = transform.position.y + delta;
                transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
            }
        }

        public void SaySomething()
        {
            Debug.Log("Я могу говорить!!!");
        }
    }

}

