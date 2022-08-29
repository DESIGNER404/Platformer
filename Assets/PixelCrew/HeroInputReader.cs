using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private HeroInputActions _inputActions;

        private void Awake()
        {
            _inputActions = new HeroInputActions();
            _inputActions.Hero.HorizontalMovement.performed += OnHorizontalMovement;
            _inputActions.Hero.HorizontalMovement.canceled += OnHorizontalMovement;
            _inputActions.Hero.VerticalMovement.performed += OnVerticalMovement;
            _inputActions.Hero.VerticalMovement.canceled += OnVerticalMovement;
            _inputActions.Hero.SaySomething.performed += OnSaySomething;
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnHorizontalMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            _hero.SetDirectionHorizontal(direction);
        }

        private void OnVerticalMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            _hero.SetDirectionVertical(direction);
        }

        private void OnSaySomething(InputAction.CallbackContext context)
        {
            _hero.SaySomething();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Ineract();
            }
        }
    }
}
