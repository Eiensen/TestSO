using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroDataPrefab : MonoBehaviour, IPointerDownHandler
{
    private HeroCardSO heroData;
    private CardView cardViewScript;

    // Start is called before the first frame update
    void Awake()
    {
        cardViewScript = FindObjectOfType<CardView>();
    }

    public void SetHeroData (HeroCardSO hero)
    {
        heroData = hero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cardViewScript.ViewFromInventory(heroData);
    }
}
