using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerControls controls;

    public float moveSpeed = 8f;
    public Vector2 move;
    public Vector2 m = Vector2.zero;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector2(move.x * moveSpeed * Time.fixedDeltaTime, 0f), Space.World);
    }

    void Update()
    {
        m = new Vector2(move.x, 0f) * moveSpeed * Time.deltaTime;

        m.Set(move.x * moveSpeed * Time.deltaTime, 0f);
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
