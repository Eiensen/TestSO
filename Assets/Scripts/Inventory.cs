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
    // Start is called before the first frame update
    void Awake()
    {
        cardViewScript.SetMediator(this);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notify(object sender, HeroCardSO heroData)
    {
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
       
    }
}
