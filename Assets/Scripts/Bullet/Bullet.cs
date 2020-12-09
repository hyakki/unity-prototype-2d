using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 30f;

    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.CompareTag("Player")) {
            Kill();
        }
    }

    void Update()
    {
        Vector3 target = transform.position + (direction * speed * Time.deltaTime);
        transform.position = target;

        float dist = (Vector3.zero - transform.position).magnitude;

        if (dist > 20f) {
            Kill();
        }
    }

    void Kill() {
        Destroy(gameObject);
    }
}
