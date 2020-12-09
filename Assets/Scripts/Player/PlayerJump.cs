using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private PlayerControls controls;

    public Rigidbody2D rb;
    public int jumpCount = 2;
    public float jumpForce = 4.5f;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Jump.performed += ctx => Jump();
    }

    void Jump()
    {
        if (jumpCount > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpCount -= 1;
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
