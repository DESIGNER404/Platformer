using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private HeroInputAction _inputActions;
    private void Awake()
    {
        var inputActions = new HeroInputAction();
        inputActions.Hero.HorizontalMovement.performed += OnHorizontalMovement;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }
    private void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<float>();
        _hero.SetDirection(direction);
    }
}
