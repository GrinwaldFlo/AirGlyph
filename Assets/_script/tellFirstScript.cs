using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class tellFirstScript : MonoBehaviour
{

	private List<clGlyph> lstGlyphTellFirst = new List<clGlyph>();
	glyphScript glyph;

	// Use this for initialization
	void Start()
	{
		glyph = transform.GetChild(0).GetComponent<glyphScript>();
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

		if (!glyphOK)
		{
			logicScript.txtLastGlyph.text = "???";
			logicScript.txtMessage.text = "Glyph missed";
			glyph.glyphName = "";
			curPlayer.score--;
			logicScript.setNextPlayer();
			return;
		}

		int foundIndex = lstGlyphTellFirst.FindIndex(x => x.name == curPlayer.lastGlyph.name);

		if(foundIndex != -1)
		{
			logicScript.txtMessage.text = "Good !";
			lstGlyphTellFirst.RemoveAt(foundIndex);
			curPlayer.score++;
		}
		else
		{
			logicScript.txtMessage.text = "Already written !";
		}

		logicScript.txtLastGlyph.text = curPlayer.lastGlyph.name;
		glyph.glyphName = curPlayer.lastGlyph.names[0];


		logicScript.setNextPlayer();
	}
}
