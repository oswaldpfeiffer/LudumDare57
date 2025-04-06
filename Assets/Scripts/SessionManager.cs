using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : SingletonBaseClass<SessionManager>
{
    public Reincarnate _reincarnateLogic;

    public void StartNewGame (ELifepath path)
    {
        IdleData.LIFEPATH = path;
        IdleData.ResetData();
        _reincarnateLogic.HidePopup();
    }

}
