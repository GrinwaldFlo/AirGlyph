using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class tellFirstScript : MonoBehaviour
{
	private const int nbMissMax = 5;
	private List<clGlyph> lstGlyphTellFirst = new List<clGlyph>();
	private glyphScript[] glyph = new glyphScript[3];
	private int scoreInc = 1;
	private int nbMiss = 0;
	private logicScript logic;
	private bool endPhase;
	private float lastTime;

	void Awake()
	{
		for (int i = 0; i < glyph.Length; i++)
		{
			glyph[i] = transform.GetChild(i).GetComponent<glyphScript>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(endPhase)
		{
			if(Time.time - lastTime > 0.4)
			{
				if(lstGlyphTellFirst.Count == 0)
				{
					logic.setGameEnd();
					return;
				}
				pushGlyph();
				glyph[0].glyphName = lstGlyphTellFirst[0].names[0];
				logic.txtLastGlyph.text = lstGlyphTellFirst[0].name;
				lstGlyphTellFirst.RemoveAt(0);
				lastTime = Time.time;
			}
		}
	}

	internal void init(logicScript logic)
	{
		this.logic = logic;
		endPhase = false;
		gameObject.SetActive(true);
		lstGlyphTellFirst = new List<clGlyph>();
		lstGlyphTellFirst.AddRange(Gvar.lstGlyph);
		nbMiss = 0;
		for (int i = 0; i < glyph.Length; i++)
		{
			glyph[i].glyphName = glyphScript.NoGlyph;
		}
	}

	internal void treat(bool glyphOK, playerScript curPlayer)
	{
		if (endPhase && curPlayer.lastGlyph != null && curPlayer.lastGlyph.name == Gvar.glyphNext)
		{ 
			logic.setGameEnd();
			return;
		}

		if (!curPlayer.isCurrentPlayer)
		{
			AirConsole.instance.Message(curPlayer.deviceId, Lng.NotYourTurn);
			return;
		}

		if(glyph[0].glyphName != "")
			pushGlyph();

		if (!glyphOK)
		{
			glyph[0].glyphName = "";
			curPlayer.score--;
			logic.setNextPlayer();
			nbMiss++;

			if (nbMiss == nbMissMax)
				setEndPhase();
			else
			{
				logic.txtLastGlyph.text = Lng.NotAGlyph;
				logic.txtMessage.text = string.Format(Lng.GlyphMissed, (nbMissMax - nbMiss));
			}
			return;
		}

		int foundIndex = lstGlyphTellFirst.FindIndex(x => x.name == curPlayer.lastGlyph.name);

		if (foundIndex != -1)
		{
			nbMiss = 0;
			logic.txtMessage.text = Lng.GlyphOK;
			lstGlyphTellFirst.RemoveAt(foundIndex);
			logic.txtMessage2.text = string.Format(Lng.GlyphRemaining,  lstGlyphTellFirst.Count);
			curPlayer.score += scoreInc;
			scoreInc++;
		}
		else
		{
			nbMiss++;
			if (nbMiss == nbMissMax)
				setEndPhase();
			else
				logic.txtMessage.text = string.Format(Lng.AlreadyWritten, (nbMissMax - nbMiss));
		}

		logic.txtLastGlyph.text = curPlayer.lastGlyph.name;
		glyph[0].glyphName = curPlayer.lastGlyph.names[0];


		logic.setNextPlayer();
	}

	private void setEndPhase()
	{
		lastTime = Time.time;
		logic.txtMessage.text = Lng.GlyphMissedList;
		logic.txtMessage2.text = Lng.Skip;
		endPhase = true;
		AirConsole.instance.Broadcast(Cmd.Active);
		AirConsole.instance.Broadcast(logic.txtMessage2.text);
	}

	private void pushGlyph()
	{
		for (int i = glyph.Length - 1; i > 0; i--)
		{
			glyph[i].glyphName = glyph[i - 1].glyphName;
		}
		glyph[0].glyphName = glyphScript.NoGlyph;
	}
}
