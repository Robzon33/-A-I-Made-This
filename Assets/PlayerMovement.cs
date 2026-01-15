using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private PlayerInputHandler input;

    void Awake()
    {
        input = GetComponent<PlayerInputHandler>();

        if (input == null)
        {
            Debug.LogError(
                "PlayerInputHandler NICHT gefunden! " +
                "PlayerMovement und PlayerInputHandler müssen auf DEMSELBEN GameObject sein."
            );
        }
    }

    void Update()
    {
        Vector2 moveInput = input.Move;

        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        transform.position += move * speed * Time.deltaTime;
    }
}