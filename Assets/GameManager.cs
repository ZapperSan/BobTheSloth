using Assets.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets
{
    class GameManager : MonoBehaviour
    {
        public GameObject Dice;
        public GameObject PlayerCard;
        private int turn;
        private List<Character> PlayerHeroes;
        private List<Character> EnemyMonsters;
        private List<Character> CharacterList;
        private List<GameObject> Dices;
        public Vector3 DiceSpawinPoint;

        private void Update()
        {
            switch (this.turn)
            {
                case 1:
                    int endChar = 0;
                    foreach (Character character in EnemyMonsters)
                    {
                        if(!character.GetDice().GetEnd())
                        {
                            character.ThrowDice();
                        }
                        else
                        {
                            character.GetDice().MoveDice(character.getCardV3());
                            endChar++;
                        }
                        if (endChar == EnemyMonsters.Count()) this.turn++;
                    }
                    break;
                case 2:
                    int endChar1 = 0;
                    foreach (Character character in PlayerHeroes)
                    {
                        if (!character.GetDice().GetEnd())
                        {
                            character.ThrowDice();
                        }
                        else
                        {
                            character.GetDice().MoveDice(character.getCardV3());
                            endChar1++;
                        }
                        if (endChar1 == PlayerHeroes.Count()) this.turn++;
                    }
                    break; 
                case 3:
                    break;
            }
        }

        private void Start()
        {
            this.DiceSpawinPoint = this.transform.position;
            PlayerHeroes = new List<Character>();
            EnemyMonsters = new List<Character>();
            CharacterList = new List<Character>();
            GenerateHeroesList();
            EnemyMonsters.Add(CharacterList[0]);
            EnemyMonsters.Add(CharacterList[1]);
            EnemyMonsters.Add(CharacterList[2]);
            EnemyMonsters.Add(CharacterList[3]);

            PlayerHeroes.Add(CharacterList[0]);
            PlayerHeroes.Add(CharacterList[1]);
            PlayerHeroes.Add(CharacterList[2]);
            PlayerHeroes.Add(CharacterList[3]);
            MonsterPrepare();
            PrepareArena();
            this.turn = 1;
        }

        private void GenerateHeroesList()
        {
            // I'm sorry for this ...

            this.CharacterList.Add(new Character(12, "Blacksmith", true, new UnityEngine.Color(0.5f, 0.5f, 0.5f),
                GetDiceTokens(2, 2, 1, 1, 1, 0, "shield", "shield", "hit", "hit", "shield", "nothing")));

            this.CharacterList.Add(new Character(15, "Drunkard", true, new UnityEngine.Color(0.9f, 1, 0.258f),
                GetDiceTokens(3, 2, 1, 1, 0, 0, "taunt", "hit", "hit", "hit", "nothing", "nothing")));

            this.CharacterList.Add(new Character(9, "Herbalist", true, new UnityEngine.Color(0.51f, 0.8f, 0.79f),
                GetDiceTokens(3, 2, 0, 0, 2, 1, "heal", "hit", "nothing", "nothing", "heal", "heal")));

            this.CharacterList.Add(new Character(8, "Hunter", true, new UnityEngine.Color(0.1f, 0.52f, 0, 1f),
                GetDiceTokens(3, 1, 2, 2, 0, 0, "hit", "heal", "hit", "hit", "nothing", "nothing")));

            this.CharacterList.Add(new Character(10, "Innkeeper", true, new UnityEngine.Color(0.79f, 0.16f, 1f),
                GetDiceTokens(2, 1, 1, 1, 1, 1, "heal", "shield", "hit", "hit", "shield", "shield")));
        }

        private DiceToken[] GetDiceTokens(int firstPip, int secondPip, int ThirdPip, int FourthPip, int FifthPip, int SixthPip,
    string firstAction, string secondAction, string ThirdAction, string FourthAction, string FifthAction, string SixthAction)
        {
            DiceToken[] diceTokens = new DiceToken[6];

            diceTokens[0] = new DiceToken(SideEnum.Front, firstPip, firstAction);
            diceTokens[1] = new DiceToken(SideEnum.Top, secondPip, secondAction);
            diceTokens[2] = new DiceToken(SideEnum.Right, ThirdPip, ThirdAction);
            diceTokens[3] = new DiceToken(SideEnum.Left, FourthPip, FourthAction);
            diceTokens[4] = new DiceToken(SideEnum.Back, FifthPip, FifthAction);
            diceTokens[5] = new DiceToken(SideEnum.Bottom, SixthPip, SixthAction);
            return diceTokens;
        }

        public void GenerateArena()
        {
        }

        public void HeroTurn()
        {
            foreach (var character in PlayerHeroes)
            {
                //Spawn kostky
            }
        }
        public void MonsterPrepare()
        {
            int i = 0;
            foreach (var character in EnemyMonsters)
            {
                var dice = Instantiate(Dice, DiceSpawinPoint + new Vector3(0, 0, 2 * i), transform.rotation);
                character.SetDice(dice);
                i++;
            }
        }
        public void MonsterTurn()
        {
            /*
             *
             *
             *
             *
             *
             */
            this.MonsterPrepare();
        }
        public void PrepareArena()
        {
            int i = 0;
            foreach(Character character in PlayerHeroes)
            {
                var GenCharCard = Instantiate(PlayerCard,new Vector3(-7.5f + (i*4.2f),0, -3.9f),transform.rotation);
                character.SetCard(GenCharCard);
                i++;
            }
            i = 0;
            foreach(Character character in EnemyMonsters)
            {
                var GenCharCard = Instantiate(PlayerCard, new Vector3(7.6f - (i * 4.2f), 0f, 3.3f), transform.rotation);
                character.SetCard(GenCharCard);
                i++;
            }
        }
    }
}
