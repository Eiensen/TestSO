using System.Collections;
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
   

    public void StartButton()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        HeroCardSO heroCardTmp = heroCard[Random.Range(0, 4)];
        SetBorderColor(heroCardTmp);
        SetCardInfo(heroCardTmp);
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
        attackValue.text = (heroCard.GetAttackFactor() * 150).ToString();
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
