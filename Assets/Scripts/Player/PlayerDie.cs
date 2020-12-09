using System.Collections;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private PlayerControls controls;

    public GameObject graphics;
    private Material material;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.TriggerDie.performed += ctx => TriggerDie();
        controls.Gameplay.TriggerRevive.performed += ctx => TriggerRevive();

        material = graphics.GetComponent<SpriteRenderer>().material;
    }

    void TriggerDie()
    {
        StartCoroutine("FadeOut");
    }

    void TriggerRevive()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeOut() {
        while (true)
        {
            float current = material.GetFloat("_Fade");

            if (current < 1f) {
                material.SetFloat("_Fade", current + Time.deltaTime);
            } else {
                StopCoroutine("FadeOut");
            }

            yield return true;
        }
    }

    IEnumerator FadeIn() {
        while (true)
        {
            float current = material.GetFloat("_Fade");

            if (current > 0f) {
                material.SetFloat("_Fade", current - Time.deltaTime);
            } else {
                StopCoroutine("FadeIn");
            }

            yield return true;
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