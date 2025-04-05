using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_KarmaBreathMult : UpgradeItemParent
{
    public override double GetNewUpgradePrice()
    {
        return IdleData.GetKarmaMultiplierCost();
    }

    public override int GetUpgradeLevel()
    {
        return IdleData.KARMA_MULTIPLIER_LEVEL + 1;
    }

    public override string GetValue()
    {
        return IdleData.GetKarmaMultiplier().ToString("0.00");
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
