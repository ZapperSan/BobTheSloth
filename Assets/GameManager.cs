using Assets.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class GameManager : MonoBehaviour
    {
        public GameObject Dice;

        static GameManager _Instance;
        public static GameManager Instance
        {
            get
            {
                if (_Instance == null) _Instance = new GameManager();
                return _Instance;
            }
        }

        private int turn;
        private List<Character> PlayerHeroes;
        private List<Character> EnemyMonsters;
        private List<Character> CharacterList;
        private List<GameObject> Dices;
        public Vector3 DiceSpawinPoint;
        Database db;

        private void Update()
        {
            switch (this.turn)
            {
                case 0:
                    this.turn = 1;
                    MonsterPrepare();
                    break;
                case 1:
                    foreach (Character character in EnemyMonsters)
                    {
                        if(!character.GetDice().GetEnd())
                        {
                            character.ThrowDice();
                        }
                    }
                    break;
                case 2:
                    break; 
                case 3:
                    break;
            }
        }

        private void Start()
        {
            turn = 0;
            this.DiceSpawinPoint = this.transform.position;
            PlayerHeroes = new List<Character>();
            EnemyMonsters = new List<Character>();
            CharacterList = new List<Character>();

            GenerateHeroesList();

            EnemyMonsters.Add(CharacterList[0]);
            EnemyMonsters.Add(CharacterList[1]);
            EnemyMonsters.Add(CharacterList[2]);
            EnemyMonsters.Add(CharacterList[3]);
        }

        private void GenerateHeroesList()
        {
            // I'm sorry for this ...

            CharacterList.Add(new Character(12, "Blacksmith", true, new UnityEngine.Color(0.5f, 0.5f, 0.5f),
                GetDiceTokens(2, 2, 1, 1, 1, 0, "shield", "shield", "hit", "hit", "shield", "nothing")));

            CharacterList.Add(new Character(15, "Drunkard", true, new UnityEngine.Color(0.9f, 1, 0.258f),
                GetDiceTokens(3, 2, 1, 1, 0, 0, "taunt", "hit", "hit", "hit", "nothing", "nothing")));

            CharacterList.Add(new Character(9, "Herbalist", true, new UnityEngine.Color(0.51f, 0.8f, 0.79f),
                GetDiceTokens(3, 2, 0, 0, 2, 1, "heal", "hit", "nothing", "nothing", "heal", "heal")));

            CharacterList.Add(new Character(8, "Hunter", true, new UnityEngine.Color(0.1f, 0.52f, 0, 1f),
                GetDiceTokens(3, 1, 2, 2, 0, 0, "hit", "heal", "hit", "hit", "nothing", "nothing")));

            CharacterList.Add(new Character(10, "Innkeeper", true, new UnityEngine.Color(0.79f, 0.16f, 1f),
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
    }
}
