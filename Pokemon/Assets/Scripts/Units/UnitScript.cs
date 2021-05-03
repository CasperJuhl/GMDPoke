using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string Name;

    public int Level;

    public int damage;

    public int HP;

    public int currentHP;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)    {
        currentHP += amount;
        if(currentHP > HP)
        {
            currentHP = HP;
        }
    }

    public bool Run()
    {
        if (Random.Range(1, 101) <= 60) //40% change of not escaping
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
