using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : SingletonBaseClass<SessionManager>
{
    public Reincarnate _reincarnateLogic;

    public GameObject ChiStore;
    public GameObject KarmaStore;
    public GameObject ReincarnationStore;

    public List<Sprite> Clothes;

    public SpriteRenderer ClothesSprite;

    public Animator Flash;

    private void Start()
    {
        ChiStore.SetActive(false);
        KarmaStore.SetActive(false);
        ReincarnationStore.SetActive(false);
        Flash.SetTrigger("Flash");
    }

    public void StartNewGame (ELifepath path)
    {
        Flash.SetTrigger("Flash");
        IdleData.LIFEPATH = path;
        IdleData.ResetData();
        _reincarnateLogic.HidePopup();
        ClothesSprite.sprite = Clothes[IdleData.INCARNATION % Clothes.Count];
    }

    private void Update()
    {
        if (IdleData.KARMA > 5) ChiStore.SetActive(true);
        if (IdleData.KARMA > 10) KarmaStore.SetActive(true);
        if (IdleData.KARMA > 15) ReincarnationStore.SetActive(true);
    }
}
