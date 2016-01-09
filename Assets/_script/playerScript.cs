using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;



public class playerScript : MonoBehaviour, IComparable<playerScript>
{
	internal int deviceId;
	internal int player;
	internal string playerName;
	public Text txtName;
	public Text txtScore;
	public Text txtScoreGlob;
	private Image backgroundImage;
	internal bool isCurrentPlayer;
	internal clGlyph lastGlyph;

	private int p_score;
	public int score
	{
		get
		{
			return p_score;
		}
		set
		{
			if(value != score)
			{
				p_score = value;
				txtScore.text = p_score.ToString();
			}
		}
	}

	private int p_scoreGlob;
	public int scoreGlob
	{
		get
		{
			return p_scoreGlob;
		}
		set
		{
			if (value != scoreGlob)
			{
				p_scoreGlob = value;
				txtScoreGlob.text = p_scoreGlob.ToString();
			}
		}
	}


	internal void setScore(int score)
	{

	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void FixedUpdate()
	{

	}

	internal void init(int deviceId)
	{
		this.deviceId = deviceId;
		player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(deviceId);
		playerName = AirConsole.instance.GetNickname(deviceId);
		AirConsole.instance.Message(deviceId, "Welcome " + playerName);

		txtName.text = playerName;
		txtScore.text = score.ToString();

		backgroundImage = this.GetComponent<Image>();
	}



	internal msgResponse treatMessage(JToken data)
	{
		if (data["glyph"] != null)
		{
			JToken prevJ = data["glyph"]["circles"].First;
			if (prevJ == null)
				return msgResponse.BadGlyph;
			JToken curJ = prevJ.Next;
			List<clSegment> lstSeg = new List<clSegment>();

			while (curJ != null)
			{
				lstSeg.Add(new clSegment(prevJ.Value<int>("id") , curJ.Value<int>("id")));
				prevJ = curJ;
				curJ = curJ.Next;
			}

			lstSeg.Sort();
			for (int i = 1; i < lstSeg.Count; i++)
			{
				if (lstSeg[i - 1].id == lstSeg[i].id)
				{
					lstSeg.RemoveAt(i);
					i--;
				}
			}

			string s = "";
			for (int i = 0; i < lstSeg.Count; i++)
			{
				s += lstSeg[i].id + ",";
			}

			int[] r = new int[lstSeg.Count];
			for (int i = 0; i < r.Length; i++)
			{
				r[i] = lstSeg[i].id;
			}

			lastGlyph = getGlyph(r);

			if(lastGlyph == null)
			{
				AirConsole.instance.Message(deviceId, "@Not a glyph");
				Debug.Log(s);
				return msgResponse.BadGlyph;
			}
			else
			{
				AirConsole.instance.Message(deviceId, "@" + lastGlyph.name);
				return msgResponse.GoodGlyph;
			}
		}
		else
		{
			Debug.Log("Message from player " + player + " " + data.ToString());
		}
		return msgResponse.None;
	}

	private clGlyph getGlyph(int[] pattern)
	{
		for (int i = 0; i < Gvar.lstGlyph.Count; i++)
		{
			if (ArraysEqual(pattern, Gvar.lstGlyph[i].pattern))
			{
				return Gvar.lstGlyph[i];
			}
		}
		return null;
	}

	static bool ArraysEqual(int[] a1, int[] a2)
	{
		if (ReferenceEquals(a1, a2))
			return true;

		if (a1 == null || a2 == null)
			return false;

		if (a1.Length != a2.Length)
			return false;

		for (int i = 0; i < a1.Length; i++)
		{
			if (a1[i] != a2[i]) return false;
		}
		return true;
	}

	public int CompareTo(playerScript other)
	{
		return other.score.CompareTo(score);
	}

	internal void setActive(bool v)
	{
		isCurrentPlayer = v;
		backgroundImage.color = v ? Color.red : Color.white;
		AirConsole.instance.Message(deviceId, v ? "#Active" : "#Inactive");
	}
}
