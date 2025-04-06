using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemParent : MonoBehaviour
{
    public Button _button;
    public TMP_Text _priceText;
    public TMP_Text _levelText;
    public TMP_Text _valueText;

    public Animator Stars;
    public void Update()
    {
        _button.interactable = IsPurchasable();
        _priceText.text = UnitsFormatter.Format(GetNewUpgradePrice());
        _levelText.text = "Level " + GetUpgradeLevel().ToString();
        _valueText.text = GetValue();
    }

    public virtual void OnClick()
    {
        Stars.SetTrigger("Play");
    }

    public bool IsPurchasable ()
    {
        return IdleData.CHI >= GetNewUpgradePrice();
    }

    public virtual double GetNewUpgradePrice ()
    {
        return 0;
    }

    public virtual int GetUpgradeLevel()
    {
        return 0;
    }

    public virtual string GetValue()
    {
        return "";
    }
}
