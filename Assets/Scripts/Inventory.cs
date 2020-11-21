using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Inventory : MonoBehaviour, IHeroData
{
    public GameObject heroIconPrefab;
    public CardView cardViewScript;
    public Transform parent;
    private int inventorySize = 1;
    private int inventoryMaxSize = 12;
    private List<HeroCardSO> heroesList = new List<HeroCardSO>();
    // Start is called before the first frame update
    void Awake()
    {
        cardViewScript.SetMediator(this);
    }

    public void Notify(object sender, HeroCardSO heroData)
    {
        if (inventorySize <= inventoryMaxSize)
        {
            heroesList.Add(heroData);
            inventorySize++;
        }
        else return;

        GameObject heroIcon = Instantiate(heroIconPrefab) as GameObject;
        
        heroIcon.transform.SetParent(parent, false);
        heroIcon.GetComponentInChildren<TextMeshProUGUI>().text = heroData.name;
        switch (heroData.warriorGrade)
        {
            case HeroCardSO.XColor.grey:
                heroIcon.GetComponent<Image>().color = Color.grey;
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "x1";
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().color = Color.grey;                
                break;
            case HeroCardSO.XColor.green:
                heroIcon.GetComponent<Image>().color = Color.green;
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "x2";
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
                break;
            case HeroCardSO.XColor.blue:
                heroIcon.GetComponent<Image>().color = Color.blue;
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = "x3";
                heroIcon.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().color = Color.blue;
                break;
        }
        heroIcon.GetComponent<HeroDataPrefab>().SetHeroData(heroData);
    }
   
}
