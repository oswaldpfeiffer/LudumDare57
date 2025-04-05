using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_KarmaAmount : UpgradeItemParent
{

    public override double GetNewUpgradePrice()
    {
        return IdleData.GetKarmaAmountCost();
    }
    public override int GetUpgradeLevel()
    {
        return IdleData.KARMA_AMOUNT_LEVEL + 1;
    }

    public override string GetValue()
    {
        return IdleData.GetKarmaAmount().ToString("0.00");
    }

    public override void OnClick()
    {
        base.OnClick();
        if (IsPurchasable())
        {
            IdleData.CHI -= GetNewUpgradePrice();
            IdleData.KARMA_AMOUNT_LEVEL++;
        }
    }
}
