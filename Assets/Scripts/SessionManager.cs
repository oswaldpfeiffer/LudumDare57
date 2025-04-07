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
    public AudioSource FlashSound;

    private void Start()
    {
        int o = PlayerPrefs.GetInt("OpenedOnce", 0);
        ChiStore.SetActive(o == 1);
        KarmaStore.SetActive(o == 1);
        ReincarnationStore.SetActive(o == 1);
        Flash.SetTrigger("Flash");
        FlashSound.Play();
        PlayerPrefs.SetInt("OpenedOnce", 1);
    }

    public void StartNewGame (ELifepath path)
    {
        Flash.SetTrigger("Flash");
        FlashSound.Play();
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
