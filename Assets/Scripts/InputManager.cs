using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [field: SerializeField] public UnityEvent OnMoveUp { get; set; }
    [field: SerializeField] public UnityEvent OnMoveDown { get; set; }
    [field: SerializeField] public UnityEvent OnBallTriggerPress { get; set; }
    
    private bool _isMovingUp;
    private bool _isBallTriggered;
    private bool _isMovingDown;

    private void FixedUpdate()
    {
        if(_isMovingUp) OnMoveUp?.Invoke();
        if(_isMovingDown) OnMoveDown?.Invoke();
        if(_isBallTriggered) OnBallTriggerPress?.Invoke();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var direction = context.ReadValue<Vector2>();
            switch (direction.y)
            {
                case > 0:
                    _isMovingUp = true;
                    break;
                case < 0:
                    _isMovingDown = true;
                    break;
            }
        }
        else
        {
            _isMovingUp = false;
            _isMovingDown = false;
        }
    }
    
    public void OnBallTrigger(InputAction.CallbackContext context)
    {
        _isBallTriggered = context.performed;
    }
}
