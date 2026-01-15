using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ControllerButtonHandler : MonoBehaviour
{
    public Button prompt1Button;
    public Button prompt2Button;
    public Button prompt3Button;
    public Button exitButton;

    private Gamepad gamepad;

    void Update()
    {
        // Prüfe, ob ein Gamepad verbunden ist
        gamepad = Gamepad.current;
        if (gamepad == null) return;

        // Prüfe, ob A gedrückt wurde
        if (gamepad.aButton.wasPressedThisFrame)
        {
            exitButton.onClick.Invoke();  // löst das Button-Event aus
        }

        if (gamepad.xButton.wasPressedThisFrame)
        {
            prompt1Button.onClick.Invoke();
        }
    }
}