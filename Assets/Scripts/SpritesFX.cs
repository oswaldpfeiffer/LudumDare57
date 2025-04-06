using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesFX : SingletonBaseClass<SpritesFX>
{
    public Transform KarmaContainer;
    public Transform ChiContainer;

    public GameObject KarmaPrefab;
    public GameObject ChiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSpeed ()
    {
        return BreatheLogic.Instance.IsBreathingBoost() ? 30f : 10f;
    }

    public void SpawnKarma ()
    {
        if (KarmaContainer.GetChild(0).gameObject.activeSelf)
        {
            GameObject g = Instantiate(KarmaPrefab, KarmaContainer);
            g.transform.SetAsLastSibling();
            g.GetComponent<Collectible>().Create();
        } else
        {
            KarmaContainer.GetChild(0).gameObject.GetComponent<Collectible>().Create();
        }
    }

    public void SpawnChi ()
    {
        if (ChiContainer.GetChild(0).gameObject.activeSelf)
        {
            GameObject g = Instantiate(ChiPrefab, ChiContainer);
            g.transform.SetAsLastSibling();
            g.GetComponent<Collectible>().Create();
        }
        else
        {
            ChiContainer.GetChild(0).gameObject.GetComponent<Collectible>().Create();
        }
    }
}
