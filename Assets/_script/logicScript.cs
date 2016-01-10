using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

public class logicScript : MonoBehaviour
{
	public GameObject introCanvas;
	public GameObject readyCanvas;
	public GameObject playCanvas;
	public GameObject endCanvas;
	public GameObject uiPlayLeft;
	public GameObject uiPlayRight;
	public GameObject prefabPlayer;

	public GameObject introScene;
	public GameObject tellFirstScene;
	public GameObject findSentenceScene;

	public Text txtLastGlyph;
	public Text txtMessage;
	public Text txtMessage2;
	public Text txtHelp;
	public Text txtFinalText;

	private float timeStateChange;

	public playerScript[] lstPlayer = new playerScript[Gvar.nbPlayerMax];

	public delegate void StateChangeAction();
	public static event StateChangeAction OnStateChange;
	public int currentPlayer = -1;


	void Awake()
	{
		AirConsole.instance.onConnect += Instance_onConnect;
		AirConsole.instance.onCustomDeviceStateChange += Instance_onCustomDeviceStateChange;
		AirConsole.instance.onDeviceStateChange += Instance_onDeviceStateChange;
		AirConsole.instance.onDisconnect += Instance_onDisconnect;
		AirConsole.instance.onMessage += Instance_onMessage;
		AirConsole.instance.onReady += Instance_onReady;
		init();
	}

	private void Instance_onReady(string code)
	{
		Debug.Log("Ready " + code);
	}

	private void init()
	{
		setGameState(enGameState.Intro);

		Gvar.generateGlyph();
	}

	private void setGameState(enGameState state)
	{
		if (Gvar.gameState != state)
		{
			Gvar.setGameState(state);
			timeStateChange = Time.time;
			if (OnStateChange != null)
				OnStateChange();


			switch (state)
			{
				case enGameState.Intro:
					introCanvas.SetActive(true);
					readyCanvas.SetActive(false);
					playCanvas.SetActive(false);
					endCanvas.SetActive(false);
					introScene.SetActive(true);
					tellFirstScene.SetActive(false);
					findSentenceScene.SetActive(false);
					setAllPlayerInactive();
					if (AirConsole.instance.GetActivePlayerDeviceIds.Count > 0)
					{
						AirConsole.instance.Broadcast(Cmd.Active);
						AirConsole.instance.Broadcast(Lng.Intro);
					}
					break;
				case enGameState.Ready:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(true);
					playCanvas.SetActive(false);
					endCanvas.SetActive(false);
					break;
				case enGameState.Play:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(false);
					endCanvas.SetActive(false);
					introScene.SetActive(false);
					break;
				case enGameState.End:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(false);
					playCanvas.SetActive(false);
					endCanvas.SetActive(true);
					tellFirstScene.SetActive(false);
					findSentenceScene.SetActive(false);
					setAllPlayerInactive();
					if (AirConsole.instance.GetActivePlayerDeviceIds.Count > 0)
					{
						AirConsole.instance.Broadcast(Cmd.Active);
						AirConsole.instance.Broadcast(Lng.End);
					}
						
					break;
				default:
					break;
			}
		}
	}

	internal void setNextPlayer()
	{
		setNextPlayerId();

		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				lstPlayer[i].setActive(i == currentPlayer);
			}
		}
	}

	private void setAllPlayerInactive()
	{
		currentPlayer = -1;
		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				lstPlayer[i].setActive(i == currentPlayer);
			}
		}
	}

	private void setNextPlayerId()
	{
		if (currentPlayer == -1)
		{
			currentPlayer = Mathf.CeilToInt(UnityEngine.Random.Range(0, lstPlayer.Length));
		}

		for (int i = currentPlayer + 1; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				currentPlayer = i;
				return;
			}
		}
		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				currentPlayer = i;
				return;
			}
		}
	}

	private void Instance_onMessage(int from, JToken data)
	{
		int numPlayer = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);

		if (lstPlayer[numPlayer] == null)
		{
			Debug.Log("Player " + numPlayer + " doesn't exists");
			return;
		}

		msgResponse r = lstPlayer[numPlayer].treatMessage(data);

		switch (Gvar.gameState)
		{
			case enGameState.None:
				break;
			case enGameState.Intro:
				if (r == msgResponse.GoodGlyph)
					treatIntro(lstPlayer[numPlayer].lastGlyph.name);
				break;
			case enGameState.Ready:
				break;
			case enGameState.Play:
				treatPlay(r == msgResponse.GoodGlyph, lstPlayer[numPlayer]);
				break;
			case enGameState.End:
				if (r == msgResponse.GoodGlyph && lstPlayer[numPlayer].lastGlyph.name == Gvar.glyphNext)
					setGameState(enGameState.Intro);
				break;
			default:
				break;
		}
	}

	private void treatPlay(bool glyphOK, playerScript curPlayer)
	{
		switch (Gvar.game)
		{
			case enGame.None:
				break;
			case enGame.FindSentence:
				findSentenceScene.GetComponent<findSentenceScript>().treat(glyphOK, curPlayer);
				break;
			case enGame.TellFirst:
				tellFirstScene.GetComponent<tellFirstScript>().treat(glyphOK, curPlayer);
				break;
			default:
				break;
		}
	}

	private void treatIntro(string name)
	{
		if (name == "Advance")
			setGame(enGame.TellFirst);
		else if (name == "Courage")
			setGame(enGame.FindSentence);
	}

	private void resetPlayerScore()
	{
		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				lstPlayer[i].score = 0;
			}
		}
	}

	private void setGame(enGame newGame)
	{
		Gvar.game = newGame;
		setAllPlayerInactive();
		resetPlayerScore();
		txtLastGlyph.text = "";
		txtMessage.text = "";
		txtMessage2.text = "";
		playCanvas.SetActive(true);
		switch (newGame)
		{
			case enGame.TellFirst:
				txtHelp.text = Lng.TellFirstHelp;
				tellFirstScene.SetActive(true);
				tellFirstScene.GetComponent<tellFirstScript>().init(this);
				setGameState(enGameState.Play);
				break;
			case enGame.FindSentence:
				txtHelp.text = Lng.FindSequenceHelp;
				findSentenceScene.SetActive(true);
				findSentenceScene.GetComponent<findSentenceScript>().init(this);
				setGameState(enGameState.Play);
				break;
			default:
				break;
		}
	}

	internal void setGameEnd()
	{
		playerScript winner = null;
		List<playerScript> lst = new List<playerScript>();
		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
				lst.Add(lstPlayer[i]);
		}

		lst.Sort();

		for (int i = 0; i < lst.Count; i++)
		{
			lst[i].scoreGlob += lst.Count - i - 1;
		}
		winner = lst[0];

		if (winner != null)
			txtFinalText.text = String.Format(Lng.Win, winner.playerName, winner.score);
		else
			txtFinalText.text = Lng.Lose;

		setGameState(enGameState.End);
	}

	private void Instance_onDisconnect(int device_id)
	{
		Debug.Log("Disconnected " + device_id);

		deletePlayer(device_id);
	}

	private void deletePlayer(int device_id)
	{
		int numPlayer = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

		if (lstPlayer[numPlayer] != null)
		{
			Destroy(lstPlayer[numPlayer].gameObject);
			lstPlayer[numPlayer] = null;
		}
		arrangePlayer();

		if (numPlayer == currentPlayer)
			setNextPlayer();
	}

	private void Instance_onDeviceStateChange(int device_id, JToken user_data)
	{
		//	Debug.Log("State change " + device_id + " " + user_data.ToString());
	}

	private void Instance_onCustomDeviceStateChange(int device_id, JToken custom_device_data)
	{
		//Debug.Log("Custom device state change " + device_id + " " + custom_device_data.ToString());
	}

	private void Instance_onConnect(int device_id)
	{
		AirConsole.instance.SetActivePlayers(Gvar.nbPlayerMax);

		Debug.Log("Connected " + device_id);

		addPlayer(device_id);

		if (Gvar.gameState == enGameState.Intro)
		{
			AirConsole.instance.Message(device_id, Cmd.Active);
			AirConsole.instance.Message(device_id, Lng.Intro);
		}
		else
		{ 
			AirConsole.instance.Message(device_id, Cmd.Inactive);
			AirConsole.instance.Message(device_id, Lng.Wait);
		}
	}

	private void addPlayer(int device_id)
	{
		GameObject newPlayer = Instantiate(prefabPlayer);
		playerScript newScript = newPlayer.GetComponent<playerScript>();
		newScript.init(device_id);
		lstPlayer[newScript.player] = newScript;
		arrangePlayer();

		//if (currentPlayer == -1)
		//	setNextPlayer();

		newScript.setActive(currentPlayer == newScript.player);
	}

	private void arrangePlayer()
	{
		List<playerScript> lstP = new List<playerScript>();

		for (int i = 0; i < lstPlayer.Length; i++)
		{
			if (lstPlayer[i] != null)
			{
				lstP.Add(lstPlayer[i]);
			}
		}

		lstP.Sort();

		for (int i = 0; i < lstP.Count; i++)
		{
			if (i < 4)
			{
				lstP[i].transform.SetParent(uiPlayLeft.transform);
				RectTransform r = lstP[i].GetComponent<RectTransform>();
				r.anchoredPosition = new Vector2(0, i * -160);
				r.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				lstP[i].transform.SetParent(uiPlayRight.transform);
				RectTransform r = lstP[i].GetComponent<RectTransform>();
				r.anchoredPosition = new Vector2(-300, (i - 4) * -160);
				r.localScale = new Vector3(1f, 1f, 1f);
			}
		}

	}


	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Gvar.gameState == enGameState.Play && Time.time - timeStateChange > 1 && currentPlayer == -1)
		{
			setNextPlayer();
		}
	}

	public void FixedUpdate()
	{
		switch (Gvar.gameState)
		{
			case enGameState.Intro:
				break;
			case enGameState.Ready:
				break;
			case enGameState.Play:
				break;
			case enGameState.End:
				break;
			default:
				break;
		}
	}
}
