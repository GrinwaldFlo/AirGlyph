using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

public class findSentenceScript : MonoBehaviour
{
	private const int nbMissMax = 5;
	private List<clPhrase> lstPhrase = new List<clPhrase>();
	public glyphScript[] glyph = new glyphScript[5];
	private int nbMiss = 0;
	private List<clGlyph> curPhrase = new List<clGlyph>();

	private bool isEnd = false;
	private float timeEnd;
	private bool isWait = false;
	private float timeWait;
	private logicScript logic;

	void Awake()
	{
		for (int i = 0; i < glyph.Length; i++)
		{
			glyph[i] = transform.GetChild(0).GetChild(i).GetComponent<glyphScript>();
		}
		resetGlyph();
	}

	// Update is called once per frame
	void Update()
	{
		if(isEnd && Time.time - timeEnd > 5)
		{
			logic.setGameEnd();
		}
		if(isWait && Time.time - timeWait > 2)
		{
			isWait = false;
			logic.setNextPlayer();
			logic.txtLastGlyph.text = "";
			curPhrase.Clear();
			updGlyph();
		}
	}

	internal void init(logicScript logic)
	{
		this.logic = logic;
		gameObject.SetActive(true);
		lstPhrase = new List<clPhrase>();
		lstPhrase.AddRange(Gvar.lstPhrase);
		resetGlyph();
		curPhrase.Clear();
		nbMiss = 0;
		isEnd = false;
		logic.txtMessage2.text = string.Format(Lng.SequenceRemaining, lstPhrase.Count);
	}

	private void resetGlyph()
	{
		for (int i = 0; i < glyph.Length; i++)
		{
			if (glyph[i] == null)
				Debug.Log("Glyph null " + i);
			else
				glyph[i].glyphName = glyphScript.NoGlyph;
		}
	}

	internal void treat( bool glyphOK, playerScript curPlayer)
	{
		if (!curPlayer.isCurrentPlayer)
		{
			AirConsole.instance.Message(curPlayer.deviceId, Lng.NotYourTurn);
			return;
		}

		if (!glyphOK)
		{
			curPlayer.score--;
			logic.txtLastGlyph.text = Lng.NotAGlyph;

			if (nbMiss == nbMissMax)
			{
				askEnd();
			}
			else
			{
				nbMiss++;
				logic.setNextPlayer();
				logic.txtMessage.text = string.Format(Lng.GlyphMissed, (nbMissMax - nbMiss));
			}
			return;
		}
		logic.txtLastGlyph.text = curPlayer.lastGlyph.name;

		curPhrase.Add(curPlayer.lastGlyph);

		int found = findSentence();

		if (found == -1)
		{
			nbMiss++;
			if (nbMiss == nbMissMax)
			{
				askEnd();
				return;
			}
			logic.txtMessage.text = string.Format(Lng.NotASequence,  (nbMissMax - nbMiss));
		}
		else
		{
			nbMiss = 0;
			curPlayer.score += (curPhrase.Count) * 2;
			if (found >= 1000 || curPhrase.Count == 5)
			{
				if (found >= 1000)
					found -= 1000;
				lstPhrase.RemoveAt(found);
				logic.txtMessage.text = Lng.SequenceOK;
				logic.txtMessage2.text = string.Format(Lng.SequenceRemaining, lstPhrase.Count);

				isWait = true;
				timeWait = Time.time;
				updGlyph();
				return;
			}
			else
			{
				logic.txtMessage.text = Lng.SequenceGlyphOK;
			}
		}

		updGlyph();
		logic.setNextPlayer();
	}

	private void askEnd()
	{
		isEnd = true;
		timeEnd = Time.time;
		logic.txtMessage.text = Lng.SequenceLose;

		clGlyph[] tmp = curPhrase.ToArray();
		for (int i = 0; i < curPhrase.Count; i++)
		{
			Debug.Log("Phrase " + curPhrase[i].name);
		}
		for (int i = 0; i < lstPhrase.Count; i++)
		{
			if (lstPhrase[i].contains(tmp))
			{
				Debug.Log("Found phrase");
				for (int j = 0; j < glyph.Length; j++)
				{
					if (lstPhrase[i].phrase.Length > j)
					{
						glyph[j].glyphName = lstPhrase[i].phrase[j].names[0];
					}
					else
						glyph[j].glyphName = glyphScript.NoGlyph;
					
				}
				break;
			}
		}
	}

	private void updGlyph()
	{
		for (int i = 0; i < glyph.Length; i++)
		{
			if (glyph[i] == null)
				Debug.Log("Upd Glyph null " + i);
			else
			{
				if (curPhrase.Count <= i)
					glyph[i].glyphName = glyphScript.NoGlyph;
				else
					glyph[i].glyphName = curPhrase[i].names[0];
			}
		}
	}

	private int findSentence()
	{
		clGlyph[] tmp = curPhrase.ToArray();
		// Check if only the sequence occure only once
		int foundId = -1;
		int nbFound = 0;
		for (int i = 0; i < lstPhrase.Count; i++)
		{
			if (lstPhrase[i].Equals(tmp))
			{
				nbFound++;
				foundId = i;
			}
		}
		if(nbFound == 1)
			return 1000 + foundId;

		foundId = -1;
		nbFound = 0;
		// Check if sequence is partial
		for (int i = 0; i < lstPhrase.Count; i++)
		{
			if (lstPhrase[i].contains(tmp))
			{
				nbFound++;
				foundId = i;
			}
		}

		if(nbFound > 0)
			logic.txtMessage2.text = string.Format(Lng.SequenceRemaining, lstPhrase.Count) + "\r\n" +
				string.Format(Lng.SequenceStartWith, nbFound);

		if (foundId != -1)
			return foundId;

		if (curPhrase.Count < 3 || !curPhrase[curPhrase.Count - 1].hasName(Gvar.glyphEnd))
		{
			curPhrase.RemoveAt(curPhrase.Count - 1);
			return -1;
		}

		curPhrase.RemoveAt(curPhrase.Count - 1);
		tmp = curPhrase.ToArray();

		for (int i = 0; i < lstPhrase.Count; i++)
		{
			if (lstPhrase[i].Equals(tmp))
			{
				return 1000 + i;
			}
		}

		return -1;
	}


}
