using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_ChiBreathMult : UpgradeItemParent
{
    public override double GetNewUpgradePrice()
    {
        return IdleData.GetChiMultiplierCost();
    }

    public override int GetUpgradeLevel()
    {
        return IdleData.CHI_MULTIPLIER_LEVEL + 1;
    }
    public override string GetValue()
    {
        return IdleData.GetChiMultiplier().ToString("0.00");
    }

    public override void OnClick()
    {
        base.OnClick();
        if (IsPurchasable())
        {
            IdleData.CHI -= GetNewUpgradePrice();
            IdleData.CHI_MULTIPLIER_LEVEL++;
        }
    }
}
