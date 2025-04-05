using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_KarmaSpeed : UpgradeItemParent
{
    public override double GetNewUpgradePrice()
    {
        return IdleData.GetKarmaSpeedCost();
    }

    public override int GetUpgradeLevel()
    {
        return IdleData.KARMA_SPEED_LEVEL + 1;
    }

    public override string GetValue()
    {
        return IdleData.GetKarmaSpeed().ToString("0.00");
    }
    public override void OnClick()
    {
        base.OnClick();
        if (IsPurchasable())
        {
            IdleData.CHI -= GetNewUpgradePrice();
            IdleData.CHI_SPEED_LEVEL++;
        }
    }
}
