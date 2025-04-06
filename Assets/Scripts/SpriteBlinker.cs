using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpriteBlinker : SingletonBaseClass<SpriteBlinker>
{
    public SpriteRenderer spriteRenderer;
    public float blinkDuration = 0.1f; // Fast blink
    private float blinkTimer = 0f;
    private bool isBlinking = false;

    public AudioSource _audio;

    private void Start()
    {
        spriteRenderer.sharedMaterial.SetFloat("_BlinkAmount", 0f);
    }

    void Update()
    {
        if (!spriteRenderer || !spriteRenderer.sharedMaterial) return;

        if (isBlinking)
        {
            blinkTimer -= Time.deltaTime;
            if (blinkTimer <= 0f)
            {
                spriteRenderer.sharedMaterial.SetFloat("_BlinkAmount", 0f);
                isBlinking = false;
            }
        }
    }

    public void TriggerBlink()
    {
        if (!spriteRenderer || !spriteRenderer.sharedMaterial) return;

        spriteRenderer.sharedMaterial.SetFloat("_BlinkAmount", 0.1f);
        blinkTimer = blinkDuration;
        isBlinking = true;
        _audio.Play();
        _audio.pitch = Random.Range(0.9f, 1.1f);
    }
}
