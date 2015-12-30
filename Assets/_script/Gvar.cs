using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

internal static class Gvar
{
	internal const int nbPlayerMax = 8;

	internal static enGameState gameState { get; private set; }

	internal static void setGameState(enGameState state)
	{
		gameState = state;
	}

}

internal enum enGameState
{ 
	None,
	Intro,
	Ready,
	Play,
	End
}
