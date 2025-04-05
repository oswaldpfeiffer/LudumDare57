using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_ChiAmount : UpgradeItemParent
{
    public override double GetNewUpgradePrice()
    {
        return IdleData.GetChiAmountCost();
    }
    public override int GetUpgradeLevel()
    {
        return IdleData.CHI_AMOUNT_LEVEL + 1;
    }

    public override string GetValue()
    {
        return IdleData.GetChiAmount().ToString("0.00");
    }

    public override void OnClick()
    {
        base.OnClick();
        if (IsPurchasable())
        {
            IdleData.CHI -= GetNewUpgradePrice();
            IdleData.CHI_AMOUNT_LEVEL++;
        }
    }
}
