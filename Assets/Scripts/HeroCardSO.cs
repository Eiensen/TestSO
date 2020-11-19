using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class HeroCardSO : ScriptableObject
{
    public enum XColor
    {
        grey, green, blue
    }
    public enum battle
    {
        melee, range
    }
    public enum kingdoms
    {
        Gnome = 1, Human, Elf
    }

    public string ID; //Для хранения в базе данных

    public new string name; // Имя персонажа

    public XColor warriorGrade; // Грейд персонажа

    public int level; // Уровень прокачки персонажа

    public battle attackType; // Ближний или дальний бой

    public kingdoms heroRace;

    //public Sprite avatar; // Изображение персонажа

    float levelingFactor;
    float attackModeFactor;
    float defenceModeFactor;

    public Dictionary<int, float> raceFactorAttack = new Dictionary<int, float>
    {
        [1] = .0f,
        [2] = .0f,
        [3] = .0f
    }; // Именованный массив со значениеями по атаке для каждого королевства
        
    public Dictionary<int, float> raceFactorDefence = new Dictionary<int, float>
    {
        [1] = .0f,
        [2] = .0f,
        [3] = .0f
    }; // Именованный массив со значениеями по защите для каждого королевства


    [Tooltip("Описание")]

    public string description;

    private float GetLevelingFactor()
    {       
        switch (warriorGrade)
        {
            case XColor.grey:
               levelingFactor = 0.01f;
                break;
            case XColor.green:
               levelingFactor = 0.02f;
                break;
            case XColor.blue:
              levelingFactor = 0.03f;
                break;
        }
        return levelingFactor;
    }

    private float GetAttackModeFactor()
    {
        switch (attackType)
        {
            case battle.melee:
                attackModeFactor = 1.0f;
                break;
            case battle.range:
                attackModeFactor = 1.5f;
                break;            
        }
        return attackModeFactor;
    }

    private float GetDefenceModeFactor()
    {
        switch (attackType)
        {
            case battle.melee:
                defenceModeFactor = 1.3f;
                break;
            case battle.range:
                defenceModeFactor = 0.7f;
                break;          
        }
        return defenceModeFactor;
    }
 
    public float GetAttackFactor()
    {
        float result = GetAttackModeFactor() + raceFactorAttack[(int)heroRace] + (GetLevelingFactor() * level);

        return result;
    }
  
    public float GetDefenceFactor()
    {
        float result = GetDefenceModeFactor() + raceFactorDefence[(int)heroRace] + (GetLevelingFactor() * level);

        return result;
    }
}
