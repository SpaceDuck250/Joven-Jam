using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    InputActions inputActions;
    InputActions.MainActions mainActions;

    private void Awake()
    {
        inputActions = new InputActions();
        mainActions = inputActions.Main;
    }

    private void Update()
    {
        if (mainActions.click.WasPressedThisFrame())
        {
            print("lo");
        }
    }

    private void OnEnable()
    {
        mainActions.Enable();
    }

    private void OnDisable()
    {
        mainActions.Disable();
    }
}
