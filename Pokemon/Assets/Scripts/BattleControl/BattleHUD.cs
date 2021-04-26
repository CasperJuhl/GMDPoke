using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleHUD : MonoBehaviour
{
    public Text name;
    public Text level;
    public Slider HP;

    public void SetHUD(UnitScript unit)
    {
        name.text = unit.Name;
        level.text = "Lvl " + unit.Level;
        HP.maxValue = unit.HP;
        HP.value = unit.currentHP;
    }

    public void setHP(int hp)
    {
        HP.value = hp;
    }
}
