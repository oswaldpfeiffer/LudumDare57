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

    // Start is called before the first frame update
    void Start()
    {
        UpdateData();
    }

    private void UpdateData ()
    {
        _chiPrice.text = IdleData.GetReincarnationChiPrice().ToString();
        _karmaPrice.text = IdleData.GetReincarnationKarmaPrice().ToString();
        _GlobalMult.text = "Global Multiplier : " + IdleData.GetGlobalMultiplier();
        _currentIncarnation.text = "Current Incarnation : " + IdleData.INCARNATION + 1;
        _lifePath.text = "Lifepath : " + IdleData.LIFEPATH;
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

        }
    }
}
