using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELifepath
{
    Normal,
    Breathing,
    Patience,
    Consciousness
}

public static class IdleData
{
    public static double CHI = 0;
    public static double KARMA = 0;
    public static int INCARNATION = 0;

    public static int CHI_AMOUNT_LEVEL = 0;
    public static int CHI_SPEED_LEVEL = 0;
    public static int CHI_MULTIPLIER_LEVEL = 0;

    public static int CHI_AMOUNT_START = 1;
    public static int CHI_AMOUNT_INC = 1;

    public static float CHI_SPEED_START = 1f;
    public static float CHI_SPEED_INC = 0.2f;

    public static float CHI_MULT_START = 2f;
    public static float CHI_MULT_INC = 0.1f;

    public static int KARMA_AMOUNT_LEVEL = 0;
    public static int KARMA_SPEED_LEVEL = 0;
    public static int KARMA_MULTIPLIER_LEVEL = 0;

    public static int KARMA_AMOUNT_START = 1;
    public static int KARMA_AMOUNT_INC = 1;

    public static float KARMA_SPEED_START = 1f;
    public static float KARMA_SPEED_INC = 0.5f;

    public static float KARMA_MULT_START = 2f;
    public static float KARMA_MULT_INC = 0.1f;

    public static ELifepath LIFEPATH = ELifepath.Normal;

    // Base price and exponents
    private static double REINCARNATION_KARMA_PRICE = 100;
    private static double REINCARNATION_CHI_PRICE = 10000;
    private static double REINCARNATION_KARMA_EXPONENT = 1.5;
    private static double REINCARNATION_CHI_EXPONENT = 1.2;

    public static double GetChiAmount()
    {
        // Chi produit par tick (quantité)
        return CHI_AMOUNT_START + CHI_AMOUNT_LEVEL * CHI_AMOUNT_INC * GetGlobalMultiplier();
    }

    public static double GetChiSpeed()
    {
        // Vitesse de production (ticks par seconde)
        return CHI_SPEED_START + CHI_SPEED_LEVEL * CHI_SPEED_INC * GetGlobalMultiplier();
    }

    public static double GetChiMultiplier()
    {
        // Multiplicateur de production (clicks, pouvoirs, etc.)
        return CHI_MULT_START + CHI_MULTIPLIER_LEVEL * CHI_MULT_INC * GetGlobalMultiplier();
    }

    public static double GetKarmaAmount()
    {
        return KARMA_AMOUNT_START + KARMA_AMOUNT_LEVEL * KARMA_AMOUNT_INC * GetGlobalMultiplier();
    }

    public static double GetKarmaSpeed()
    {
        // Vitesse d'accumulation passive de Karma (si tu veux en ajouter)
        return KARMA_SPEED_START + KARMA_SPEED_LEVEL * KARMA_SPEED_INC * GetGlobalMultiplier();
    }

    public static double GetKarmaMultiplier()
    {
        return KARMA_MULT_START + KARMA_MULTIPLIER_LEVEL * KARMA_MULT_INC + GetGlobalMultiplier();
    }

    public static void Upgrade_Chi_Amount ()
    {
        CHI_AMOUNT_LEVEL++;
    }

    public static void Upgrade_Chi_Speed()
    {
        CHI_SPEED_LEVEL++;
    }
    public static void Upgrade_Chi_Multiplier()
    {
        CHI_MULTIPLIER_LEVEL++;
    }

    public static void Upgrade_Karma_Amount()
    {
        KARMA_AMOUNT_LEVEL++;
    }

    public static void Upgrade_Karma_Speed()
    {
        KARMA_SPEED_LEVEL++;
    }
    public static void Upgrade_Karma_Multiplier()
    {
        KARMA_MULTIPLIER_LEVEL++;
    }

    public static double GetChiAmountCost()
    {
        return System.Math.Round(10 * System.Math.Pow(1.5, CHI_AMOUNT_LEVEL)); // starts at 10, grows x1.5
    }

    public static double GetChiSpeedCost()
    {
        return System.Math.Round(50 * System.Math.Pow(2, CHI_SPEED_LEVEL)); // starts at 50, grows x2
    }

    public static double GetChiMultiplierCost()
    {
        return System.Math.Round(200 * System.Math.Pow(3, CHI_MULTIPLIER_LEVEL)); // starts at 200, grows x3
    }

    public static double GetKarmaAmountCost()
    {
        return System.Math.Round(1000 * System.Math.Pow(4, KARMA_AMOUNT_LEVEL)); // starts at 1k, x4
    }

    public static double GetKarmaSpeedCost()
    {
        return System.Math.Round(1500 * System.Math.Pow(4.2, KARMA_SPEED_LEVEL));
    }

    public static double GetKarmaMultiplierCost()
    {
        return System.Math.Round(2000 * System.Math.Pow(4.5, KARMA_MULTIPLIER_LEVEL));
    }


    // Get karma price for reincarnation
    public static double GetReincarnationKarmaPrice()
    {
        return REINCARNATION_KARMA_PRICE * Math.Pow((INCARNATION + 1), REINCARNATION_KARMA_EXPONENT);
    }

    // Get chi price for reincarnation
    public static double GetReincarnationChiPrice()
    {
        return REINCARNATION_CHI_PRICE * Math.Pow((INCARNATION + 1), REINCARNATION_CHI_EXPONENT);
    }

    // Get global multiplier for reincarnation
    public static double GetGlobalMultiplier()
    {
        return 1 + 0.5 * (INCARNATION);
    }
}
