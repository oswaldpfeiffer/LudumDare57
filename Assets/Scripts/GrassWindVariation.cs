using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GrassWindVariation : MonoBehaviour
{
    private MaterialPropertyBlock _mpb;
    private Renderer _renderer;

    [Header("Wind Settings")]
    public float windStrength = 0.2f;
    public float windSpeed = 1.0f;
    public float windScale = 1.0f;

    void Awake()
    {
        _mpb = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        // Add random offset to break uniform wind sync
        float randomOffset = Random.Range(0f, 10f);
        _mpb.SetFloat("_WindStrength", windStrength);
        _mpb.SetFloat("_WindSpeed", windSpeed);
        _mpb.SetFloat("_WindScale", windScale);
        _mpb.SetFloat("_TimeOffset", randomOffset);

        _renderer.SetPropertyBlock(_mpb);
    }
}