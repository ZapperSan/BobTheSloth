using Assets.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Character
{
    private string CharName;
    private int MaxHP;
    private int CurrentHP;
    private int Shield;
    private bool IsHero;
    private DiceToken[] DiceTokens;
    private Color BaseColor;

    private GameObject Card;
    private GameObject Dice;

    public Character(int maxHP, string name, bool isHero, Color baseColor, DiceToken[] diceTokens)
    {
        this.MaxHP = maxHP;
        this.CharName = name;
        this.CurrentHP = maxHP;
        this.Shield = 0;
        this.IsHero = isHero;
        this.BaseColor = baseColor;
        this.DiceTokens = diceTokens;
    }
    public void SetDice(GameObject dice)
    {
        this.Dice = dice;
        Dice.GetComponent<MeshRenderer>().materials[0].color = BaseColor;

        int i = 0;
        foreach (var side in Dice.GetComponent<Dice>().diceSides)
        {
            Material resource;
            string idk = DiceTokens[i].GetAction();
            switch (idk)
            {
                case ("shield"):
                    resource = Resources.Load<Material>("Materials/shield");
                    break;
                case ("sword"):
                    resource = Resources.Load<Material>("Materials/sword");
                    break;
                case ("heal"):
                    resource = Resources.Load<Material>("Materials/heart");
                    break;
                default:
                    resource = Resources.Load<Material>("Materials/nothing");
                    break;
            }
            var renderer = side.GetComponentInChildren<MeshRenderer>();
            renderer.material = resource;

            var text = side.GetComponentInChildren<TextMeshPro>();
            text.SetText(DiceTokens[i].getPips());

            i++;

        }
    }
    public void SetCard(GameObject card)
    {
        this.Card = card;
        Card.GetComponentInChildren<MeshRenderer>().materials[0].color = BaseColor;
    }
    public void ThrowDice()
    {
        Dice.GetComponent<Dice>().RollDice();
    }

    public bool getHeroStatus()
    {
        return IsHero;
    }
    public Color GetDiceColor()
    {
        return this.BaseColor;
    }
    public Dice GetDice()
    {
        return Dice.GetComponent<Dice>();
    }
    public Vector3 getCardV3()
    {
        return Card.transform.position;
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
