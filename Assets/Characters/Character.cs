using Assets.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Character
{
    private string CharName;
    private int MaxHP;
    private int CurrentHP;
    private int Shield;
    private bool IsHero;
    private DiceToken[] diceTokens;
    private Color DiceColor;

    public Character(int maxHP, string name, bool isHero, Color diceColor)
    {
        this.MaxHP = maxHP;
        this.CharName = name;
        this.CurrentHP = maxHP;
        this.Shield = 0;
        this.IsHero = isHero;
        this.DiceColor = diceColor;
    }

    public bool getHeroStatus()
    {
        return IsHero;
    }

    public bool GetHit(int dmg)
    {
        if (dmg < Shield)
        {
            this.Shield -= dmg;
        }
        else
        {
            this.CurrentHP -= (dmg - Shield);
            this.Shield = 0;
        }
        return true;
    }
    public bool Heal(int HealHP)
    {
        this.CurrentHP += HealHP;
        if (this.CurrentHP > MaxHP)
        {
            this.CurrentHP = MaxHP;
        }
        return true;
    }
    public bool GetShield(int ShieldHP)
    {
        this.Shield += ShieldHP;
        return true;
    }
}
