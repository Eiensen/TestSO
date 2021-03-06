﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public HeroCardSO[] heroCard = new HeroCardSO[5];
    public TextMeshProUGUI nameCard;
    public TextMeshProUGUI lvl;
    public TextMeshProUGUI description;
    public TextMeshProUGUI defenceValue;
    public TextMeshProUGUI attackValue;
    public TextMeshProUGUI attackMode;
    public TextMeshProUGUI grade;
    public TextMeshProUGUI kingdom;
    public GameObject border;
    public GameObject addButton;

    private IHeroData heroData;
    private HeroCardSO hero;

    private void Awake()
    {
    }

    public void SetMediator (IHeroData hero)
    {
        heroData = hero;
    }

    public void AddButton()
    {
        heroData.Notify(this, hero);

        gameObject.SetActive(false);
    }

    public void CloseButton()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
    public void ViewFromInventory(HeroCardSO heroCard)
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }       
        SetBorderColor(heroCard);
        SetCardInfo(heroCard);
        if (addButton.activeInHierarchy)
        {
            addButton.SetActive(false);
        }
    }
    public void StartButton()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        hero = heroCard[Random.Range(0, 4)];    
        SetBorderColor(hero);
        SetCardInfo(hero);
        if (!addButton.activeInHierarchy)
        {
            addButton.SetActive(true);
        }
    }

    private void SetBorderColor(HeroCardSO heroCard)
    {       
        switch (heroCard.warriorGrade)
        {
            case HeroCardSO.XColor.grey:
                border.GetComponent<Image>().color = Color.gray;
                break;
            case HeroCardSO.XColor.green:
                border.GetComponent<Image>().color = Color.green;
                break;
            case HeroCardSO.XColor.blue:
                border.GetComponent<Image>().color = Color.blue;
                break;          
        }
    }
   private void SetCardInfo(HeroCardSO heroCard)
    {
        nameCard.text = heroCard.name;
        lvl.text = heroCard.level.ToString();
        description.text = heroCard.description;
        defenceValue.text = (heroCard.GetDefenceFactor() * 100).ToString();
        attackValue.text = Mathf.RoundToInt(heroCard.GetAttackFactor() * 150).ToString();
        attackMode.text = heroCard.attackType.ToString();
        kingdom.text = "Королевство: " + heroCard.heroRace;
        switch (heroCard.warriorGrade)
        {
            case HeroCardSO.XColor.grey:
                grade.text = "x1";
                grade.color = Color.gray;
                break;
            case HeroCardSO.XColor.green:
                grade.text = "x2";
                grade.color = Color.green;
                break;
            case HeroCardSO.XColor.blue:
                grade.text = "x3";
                grade.color = Color.blue;
                break;
        }
    }
}
