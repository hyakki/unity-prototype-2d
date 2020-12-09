using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    private PlayerJump playerJump;

    public GameObject groundCheck;
    public float groundCheckRadius = 2f;
    public LayerMask groundLayerMask;

    public bool wasGrounded;
    public bool isGrounded;

    void Awake() {
        playerJump = gameObject.GetComponent<PlayerJump>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.transform.position,
            groundCheckRadius,
            groundLayerMask
        );

        if (!wasGrounded && isGrounded) {
            playerJump.jumpCount = 2;
        }

        wasGrounded = isGrounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }
}
