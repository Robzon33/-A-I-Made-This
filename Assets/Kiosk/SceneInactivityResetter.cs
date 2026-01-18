using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class SceneInactivityResetter : MonoBehaviour
{
    [Tooltip("Analog movement must exceed this to count as activity.")]
    public float analogThreshold = 0.15f;

    [Tooltip("Throttle resets so we don't spam every frame while a stick is held.")]
    public float minSecondsBetweenResets = 0.25f;

    float nextAllowedResetTime = 0f;

    void Update()
    {
        if (Time.unscaledTime < nextAllowedResetTime)
            return;

        if (DetectActivity())
        {
            nextAllowedResetTime = Time.unscaledTime + minSecondsBetweenResets;

            // If kiosk exists, reset it. If not, do nothing.
            if (KioskManager.Instance != null)
                KioskManager.Instance.ResetInactivityTimer();
        }
    }

    bool DetectActivity()
    {
#if ENABLE_INPUT_SYSTEM
        // Keyboard
        if (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame)
            return true;

        // Mouse (optional)
        if (Mouse.current != null &&
            (Mouse.current.delta.ReadValue().sqrMagnitude > 0f ||
             Mouse.current.leftButton.wasPressedThisFrame ||
             Mouse.current.rightButton.wasPressedThisFrame))
            return true;

        // Any gamepad (not just Gamepad.current)
        foreach (var gp in Gamepad.all)
        {
            if (gp == null) continue;

            // Buttons
            if (gp.startButton.wasPressedThisFrame ||
                gp.buttonSouth.wasPressedThisFrame ||
                gp.buttonNorth.wasPressedThisFrame ||
                gp.buttonEast.wasPressedThisFrame ||
                gp.buttonWest.wasPressedThisFrame ||
                gp.dpad.up.wasPressedThisFrame ||
                gp.dpad.down.wasPressedThisFrame ||
                gp.dpad.left.wasPressedThisFrame ||
                gp.dpad.right.wasPressedThisFrame)
                return true;

            // Sticks / triggers
            if (gp.leftStick.ReadValue().magnitude > analogThreshold) return true;
            if (gp.rightStick.ReadValue().magnitude > analogThreshold) return true;
            if (gp.leftTrigger.ReadValue() > analogThreshold) return true;
            if (gp.rightTrigger.ReadValue() > analogThreshold) return true;
        }
#endif
        return false;
    }
}