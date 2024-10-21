
using System; 
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputCamera : IInitializable, IDisposable
{
    public event Action<Vector2> onInputAxis;
    public event Action<Vector2> onScrollZoom;  

    private InputActions inputActions;

    private bool isPressed;
    public void Initialize()
    {
        inputActions = new InputActions();
        inputActions.Enable();
        inputActions.ActionMaps.MouseDelta.performed += ctx => MouseInputAxis(ctx);
        inputActions.ActionMaps.MouseScroll.performed += ctx => MouseScrollZoom(ctx);
        inputActions.ActionMaps.MouseMidle.performed += ctx => isPressed = true;
        inputActions.ActionMaps.MouseMidle.canceled += ctx => isPressed = false;
    } 
    public void Dispose()
    {
        inputActions.Disable();
    }

    private void MouseInputAxis(InputAction.CallbackContext context)
    {
        if (context.performed && isPressed)
            onInputAxis?.Invoke(context.ReadValue<Vector2>());
        else
            onInputAxis?.Invoke(Vector2.zero);
    }
    private void MouseScrollZoom(InputAction.CallbackContext context)
    {
        if (context.performed)
            onScrollZoom?.Invoke(context.ReadValue<Vector2>());
        else
            onScrollZoom?.Invoke(Vector2.zero);
    }

}
