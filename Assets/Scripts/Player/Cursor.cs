using UnityEngine;

public class Cursor : MonoBehaviour
{

    public Vector3 pos = Vector3.zero;

    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        
        controls.Gameplay.Target.performed += ctx => pos = ctx.ReadValue<Vector2>();
    }

    void Update() {
        float angle = Vector3.Angle(pos, Vector3.right);
        float snap = Mathf.Round(angle / 45) * 45 * Mathf.Deg2Rad;

        transform.localPosition = new Vector3(
            Mathf.Cos(snap),
            Mathf.Sin(snap) * Mathf.Sign(pos.y),
            0f
        ) * 3f;
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
