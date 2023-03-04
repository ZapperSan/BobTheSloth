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
        private List<GameObject> Dices;
        public Vector3 DiceSpawinPoint;

        private void Update()
        {
            bool hotovo = true;
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
                            hotovo = false;
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

            EnemyMonsters.Add(Database.characterList[0]);
            EnemyMonsters.Add(Database.characterList[1]);
            EnemyMonsters.Add(Database.characterList[2]);
            EnemyMonsters.Add(Database.characterList[3]);
            EnemyMonsters.Add(Database.characterList[4]);
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
