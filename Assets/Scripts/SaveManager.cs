using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Awake()
    {
        IdleData.CHI = GetDouble("CHI", 0.0);
        IdleData.KARMA = GetDouble("KARMA", 0.0);
        IdleData.INCARNATION = PlayerPrefs.GetInt("INCARNATION", 0);
        IdleData.CHI_AMOUNT_LEVEL = PlayerPrefs.GetInt("CHI_AMOUNT_LEVEL", 0);
        IdleData.CHI_SPEED_LEVEL = PlayerPrefs.GetInt("CHI_SPEED_LEVEL", 0);
        IdleData.CHI_MULTIPLIER_LEVEL = PlayerPrefs.GetInt("CHI_MULTIPLIER_LEVEL", 0);
        IdleData.KARMA_AMOUNT_LEVEL = PlayerPrefs.GetInt("KARMA_AMOUNT_LEVEL", 0);
        IdleData.KARMA_SPEED_LEVEL = PlayerPrefs.GetInt("KARMA_SPEED_LEVEL", 0);
        IdleData.KARMA_MULTIPLIER_LEVEL = PlayerPrefs.GetInt("KARMA_MULTIPLIER_LEVEL", 0);
        IdleData.LIFEPATH = (ELifepath) PlayerPrefs.GetInt("LIFEPATH", 0);
        StartCoroutine(AutoSaveRoutine());
    }

    private void OnApplicationQuit()
    {
        SaveAll();
        StopAllCoroutines();
    }

    public static void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, value.ToString("R")); // "R" ensures maximum precision
    }

    public static double GetDouble(string key, double defaultValue = 0.0)
    {
        string stored = PlayerPrefs.GetString(key, defaultValue.ToString("R"));
        if (double.TryParse(stored, out double result))
            return result;
        return defaultValue;
    }

    IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f); // every 60 seconds
            SaveAll();
        }
    }

    void SaveAll()
    {
        SetDouble("CHI", IdleData.CHI);
        SetDouble("KARMA", IdleData.KARMA);
        PlayerPrefs.SetInt("INCARNATION", IdleData.INCARNATION);
        PlayerPrefs.SetInt("CHI_AMOUNT_LEVEL", IdleData.CHI_AMOUNT_LEVEL);
        PlayerPrefs.SetInt("CHI_SPEED_LEVEL", IdleData.CHI_SPEED_LEVEL);
        PlayerPrefs.SetInt("CHI_MULTIPLIER_LEVEL", IdleData.CHI_MULTIPLIER_LEVEL);
        PlayerPrefs.SetInt("KARMA_AMOUNT_LEVEL", IdleData.KARMA_AMOUNT_LEVEL);
        PlayerPrefs.SetInt("KARMA_SPEED_LEVEL", IdleData.KARMA_SPEED_LEVEL);
        PlayerPrefs.SetInt("KARMA_MULTIPLIER_LEVEL", IdleData.KARMA_MULTIPLIER_LEVEL);
        PlayerPrefs.SetInt("LIFEPATH", (int) IdleData.LIFEPATH);
        PlayerPrefs.Save(); // especially important on WebGL
    }
}
