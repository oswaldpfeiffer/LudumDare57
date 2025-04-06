using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class KarmaVisualizerLogic : SingletonBaseClass<KarmaVisualizerLogic>
{
    public GameObject Cam;

    [SerializeField] GameObject Chakra0;
    [SerializeField] GameObject Chakra1;
    [SerializeField] GameObject Chakra2;
    [SerializeField] GameObject Chakra3;
    [SerializeField] GameObject Chakra4;
    [SerializeField] GameObject Chakra5;
    [SerializeField] GameObject Chakra6;

    [SerializeField] GameObject Aura0;
    [SerializeField] GameObject Aura1;
    [SerializeField] GameObject Aura2;
    [SerializeField] GameObject Aura3;
    [SerializeField] GameObject Aura4;
    [SerializeField] GameObject Aura5;
    [SerializeField] GameObject Aura6;

    public Volume postProcessVolume;
    private ColorAdjustments colorAdjustments;

    public AudioSource EnergySound;

    // Start is called before the first frame update
    void Start()
    {
        if (postProcessVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.Log("ColorAdjustments found!");
        }
        else
        {
            Debug.LogWarning("ColorAdjustments not found in Volume!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CamPosition();
        Chakra();
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) IdleData.KARMA += 50;
#endif
        SetSaturation();
        float karma = Mathf.Clamp((float)IdleData.KARMA, 0, 1000f);
        karma = (karma / 1000f) * 0.35f;
        EnergySound.volume = karma;
    }

    void CamPosition ()
    {
        float karma = Mathf.Clamp((float) IdleData.KARMA, 0, 1000f);
        karma = (karma / 1000f) * 19;

        float karma2 = Mathf.Clamp((float)IdleData.KARMA, 0, 1000f);
        karma2 = (karma2 / 1000f) * 4;

        Cam.transform.position = new Vector3(0, 1.5f + karma2, -6 - karma);
    }

    void Chakra ()
    {
        Chakra0.SetActive(IdleData.KARMA >= 20);
        Chakra1.SetActive(IdleData.KARMA >= 50);
        Chakra2.SetActive(IdleData.KARMA >= 100);
        Chakra3.SetActive(IdleData.KARMA >= 200);
        Chakra4.SetActive(IdleData.KARMA >= 500);
        Chakra5.SetActive(IdleData.KARMA >= 1000);
        Chakra6.SetActive(IdleData.KARMA >= 2500);

        Aura0.SetActive(IdleData.KARMA >= 20);
        Aura1.SetActive(IdleData.KARMA >= 50);
        Aura2.SetActive(IdleData.KARMA >= 100);
        Aura3.SetActive(IdleData.KARMA >= 200);
        Aura4.SetActive(IdleData.KARMA >= 500);
        Aura5.SetActive(IdleData.KARMA >= 1000);
        Aura6.SetActive(IdleData.KARMA >= 2500);
    }

    public void SetSaturation()
    {
        float karma = Mathf.Clamp((float)IdleData.KARMA, 0, 2000f);
        karma = (karma / 2000f) * 50;

        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = Mathf.Clamp(karma, -100f, 100f);
        }
    }
}
