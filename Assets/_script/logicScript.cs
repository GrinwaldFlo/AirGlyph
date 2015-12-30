using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class logicScript : MonoBehaviour
{
	public GameObject introCanvas;
	public GameObject readyCanvas;
	public GameObject endCanvas;

	private float timeStateChange;

	private playerScript[] lstPlayer = new playerScript[Gvar.nbPlayerMax];

	public delegate void StateChangeAction();
	public static event StateChangeAction OnStateChange;


	void Awake()
	{
		init();
		AirConsole.instance.onConnect += Instance_onConnect;
		AirConsole.instance.onCustomDeviceStateChange += Instance_onCustomDeviceStateChange;
		AirConsole.instance.onDeviceStateChange += Instance_onDeviceStateChange;
		AirConsole.instance.onDisconnect += Instance_onDisconnect;
		AirConsole.instance.onMessage += Instance_onMessage;
		AirConsole.instance.onReady += Instance_onReady;
	}

	private void Instance_onReady(string code)
	{
		Debug.Log("Ready " + code);
	}

	private void init()
	{
		setGameState(enGameState.Intro);
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
					endCanvas.SetActive(false);
					break;
				case enGameState.Ready:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(true);
					endCanvas.SetActive(false);
					break;
				case enGameState.Play:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(false);
					endCanvas.SetActive(false);
					break;
				case enGameState.End:
					introCanvas.SetActive(false);
					readyCanvas.SetActive(false);
					endCanvas.SetActive(true);
					break;
				default:
					break;
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

		//if (data["swipeanalog-right"] != null)
		//{
		//	if (data["swipeanalog-right"].Value<bool>("pressed") == true)
		//	{
		//		if (Gvar.gameState == enGameState.Intro)
		//			setGameState(enGameState.Ready);
		//		if (Gvar.gameState == enGameState.End && Time.time - timeStateChange > 2f)
		//			setGameState(enGameState.Intro);
		//		//				float x = data["swipeanalog-right"]["message"].Value<float>("x");
		//		//				float y = data["swipeanalog-right"]["message"].Value<float>("y");
		//		//				double a = data["swipeanalog-right"]["message"].Value<double>("angle");
		//		float d = data["swipeanalog-right"]["message"].Value<float>("degree");

		//		Debug.Log("Swipe " + d);
		//		lstPlayer[numPlayer].askThrow(d);
		//	}
		//}
		//else if (data["joystick-left"] != null)
		//{
		//	if (data["joystick-left"].Value<bool>("pressed") == true)
		//	{
		//		float x1 = data["joystick-left"]["message"].Value<float>("x");
		//		float y1 = data["joystick-left"]["message"].Value<float>("y");

		//		lstPlayer[numPlayer].move(x1, y1);
		//		//Debug.Log("Joy " + x1 + " " + y1 + " ");
		//	}
		//	else
		//	{
		//		lstPlayer[numPlayer].stopMove();
		//	}
		//}
		//else
		//{
		//	//Debug.Log("Message from " + numPlayer + " " + data.ToString());

		//}

	




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
	}

	private void addPlayer(int device_id)
	{
		int numPlayer = AirConsole.instance.ConvertDeviceIdToPlayerNumber(device_id);

		//playerScript newScript = newPlayer.GetComponent<playerScript>();
		//newScript.deviceId = device_id;
		//newScript.player = numPlayer;

		//lstPlayer[numPlayer] = newScript;

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
