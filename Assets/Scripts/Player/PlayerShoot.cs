using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private PlayerControls controls;
    private GameObject player;

    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject cursor;
    public GameObject crossCursor;
    public float shootSpeed;

    void Awake() {
        controls = new PlayerControls();

        controls.Gameplay.Shoot.performed += ctx => StartCoroutine("ShootContinuous");
        controls.Gameplay.Shoot.canceled += ctx => StopCoroutine("ShootContinuous");
    }

    void Trigger() {
        GameObject go = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().direction = 
            (
            (cursor.transform.position - bulletSpawn.transform.position).normalized +
            crossCursor.GetComponent<CrossCursor>().direction.normalized
            ).normalized;
    }

    IEnumerator ShootContinuous() {
        while(true) {
            Trigger();
            yield return new WaitForSeconds(shootSpeed);
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
