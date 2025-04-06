using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifepathButton : MonoBehaviour
{
    public ELifepath LifepathEnum;

    public void OnClick ()
    {
        SessionManager.Instance.StartNewGame(LifepathEnum);
    }
}
