using Assets;
using Assets.Characters;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Database : MonoBehaviour
{
	public static List<Character> characterList = new List<Character>();

	// Start is called before the first frame update
	void Start()
	{
		GenerateHeroesList();
	}

	private void GenerateHeroesList()
	{
		// I'm sorry for this ...

		characterList.Add(new Character(12, "Blacksmith", true, new UnityEngine.Color(0.5f, 0.5f, 0.5f),
			GetDiceTokens(2, 2, 1, 1, 1, 0, "shield", "shield", "hit", "hit", "shield", "nothing")));

		characterList.Add(new Character(15, "Drunkard", true, new UnityEngine.Color(0.9f, 1, 0.258f),
			GetDiceTokens(3, 2, 1, 1, 0, 0, "taunt", "hit", "hit", "hit", "nothing", "nothing")));

		characterList.Add(new Character(9, "Herbalist", true, new UnityEngine.Color(0.51f, 0.8f, 0.79f),
			GetDiceTokens(3, 2, 0, 0, 2, 1, "heal", "hit", "nothing", "nothing", "heal", "heal")));

		characterList.Add(new Character(8, "Hunter", true, new UnityEngine.Color(0.1f, 0.52f, 0,1f),
			GetDiceTokens(3, 1, 2, 2, 0, 0, "hit", "heal", "hit", "hit", "nothing", "nothing")));

		characterList.Add(new Character(10, "Innkeeper", true, new UnityEngine.Color(0.79f, 0.16f, 1f),
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
}
