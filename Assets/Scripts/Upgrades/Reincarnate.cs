using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reincarnate : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] TMP_Text _chiPrice;
    [SerializeField] TMP_Text _karmaPrice;
    [SerializeField] TMP_Text _currentIncarnation;
    [SerializeField] TMP_Text _GlobalMult;
    [SerializeField] TMP_Text _lifePath;

    [SerializeField] GameObject ReincarnationPopup;

    [SerializeField] GameObject Lifepath_Breathing_Icon;
    [SerializeField] GameObject Lifepath_Patience_Icon;
    [SerializeField] GameObject Lifepath_Consciousness_Icon;

    // Start is called before the first frame update
    void Start()
    {
        UpdateData();
    }

    private void UpdateData ()
    {
        _chiPrice.text = System.Math.Ceiling(IdleData.GetReincarnationChiPrice()).ToString();
        _karmaPrice.text = System.Math.Ceiling(IdleData.GetReincarnationKarmaPrice()).ToString();
        _GlobalMult.text = "Global Multiplier : " + IdleData.GetGlobalMultiplier();
        _currentIncarnation.text = "Current Incarnation : " + (IdleData.INCARNATION + 1);
        _lifePath.text = "Life path : " + IdleData.LIFEPATH;

        Lifepath_Breathing_Icon.SetActive(IdleData.LIFEPATH == ELifepath.Breathing);
        Lifepath_Patience_Icon.SetActive(IdleData.LIFEPATH == ELifepath.Patience);
        Lifepath_Consciousness_Icon.SetActive(IdleData.LIFEPATH == ELifepath.Consciousness);
    }

    // Update is called once per frame
    void Update()
    {
        _button.interactable = IdleData.CHI >= IdleData.GetReincarnationChiPrice() && IdleData.KARMA >= IdleData.GetReincarnationKarmaPrice();
    }

    public void OnReincarnationPressed ()
    {
        if (IdleData.CHI >= IdleData.GetReincarnationChiPrice() && IdleData.KARMA >= IdleData.GetReincarnationKarmaPrice())
        {
            ReincarnationPopup.SetActive(true);
        }
    }
    
    public void HidePopup ()
    {
        ReincarnationPopup.SetActive(false);
        UpdateData();
    }
}
