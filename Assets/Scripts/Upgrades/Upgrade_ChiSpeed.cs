using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_ChiSpeed : UpgradeItemParent
{
    public override double GetNewUpgradePrice()
    {
        return IdleData.GetChiSpeedCost();
    }

    public override int GetUpgradeLevel()
    {
        return IdleData.CHI_SPEED_LEVEL + 1;
    }
    public override string GetValue()
    {
        return IdleData.GetChiSpeed().ToString("0.00");
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
