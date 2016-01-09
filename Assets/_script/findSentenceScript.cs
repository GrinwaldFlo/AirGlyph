using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

public class findSentenceScript : MonoBehaviour
{
	private const int nbMissMax = 3;
	private List<clGlyph> lstGlyphTellFirst = new List<clGlyph>();
	private glyphScript[] glyph = new glyphScript[3];
	private int scoreInc = 1;
	private int nbMiss = 0;

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < glyph.Length; i++)
		{
			glyph[i] = transform.GetChild(i).GetComponent<glyphScript>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	internal void init()
	{
		gameObject.SetActive(true);
		lstGlyphTellFirst = new List<clGlyph>();
		lstGlyphTellFirst.AddRange(Gvar.lstGlyph);
	}

	internal void treat(logicScript logicScript, bool glyphOK, playerScript curPlayer)
	{
		if (!curPlayer.isCurrentPlayer)
		{
			AirConsole.instance.Message(curPlayer.deviceId, "Not your turn");
			return;
		}

		if (glyph[0].glyphName != "")
			pushGlyph();

		if (!glyphOK)
		{
			glyph[0].glyphName = "";
			curPlayer.score--;
			logicScript.setNextPlayer();
			nbMiss++;

			if (nbMiss == nbMissMax)
				logicScript.setGameEnd();

			logicScript.txtLastGlyph.text = "???";
			logicScript.txtMessage.text = "Glyph missed\r\n" + (nbMissMax - nbMiss) + " remaining tries";
			return;
		}

		int foundIndex = lstGlyphTellFirst.FindIndex(x => x.name == curPlayer.lastGlyph.name);

		if (foundIndex != -1)
		{
			nbMiss = 0;
			logicScript.txtMessage.text = "Good !";
			lstGlyphTellFirst.RemoveAt(foundIndex);
			curPlayer.score += scoreInc;
			scoreInc++;
		}
		else
		{
			nbMiss++;
			if (nbMiss == nbMissMax)
				logicScript.setGameEnd();

			logicScript.txtMessage.text = "Already written !\r\n" + (nbMissMax - nbMiss) + " remaining tries";
		}

		logicScript.txtLastGlyph.text = curPlayer.lastGlyph.name;
		glyph[0].glyphName = curPlayer.lastGlyph.names[0];


		logicScript.setNextPlayer();
	}

	private void pushGlyph()
	{
		for (int i = glyph.Length - 1; i > 0; i--)
		{
			glyph[i].glyphName = glyph[i - 1].glyphName;
		}
		glyph[0].glyphName = "";
	}
}
