using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class JSONPlayer : MonoBehaviour {
	// Use this for initialization
	public static JSONPlayer Instance = null;
	public PlayerInfo player;
	public Transform me = null;

	/*public static JSONPlayer Instacne
	{
		get
		{
			if (instance == null)
				instance = new JSONPlayer();

			return instance;
		}
	}*/
	void Start () {

		if(Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if(Instance != this)
		{
			Destroy(gameObject);
		}
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		PlayerInfo tempP = JsonUtility.FromJson<PlayerInfo>(jsonFormFile);
		if (tempP.HP <= 0)
		{
			tempP.HP = 100;
			string jsonToFile = JsonUtility.ToJson(tempP, true);
			File.WriteAllText(fliePath, jsonToFile);
		}

		//Debug.Log(JsonUtility.ToJson(newMyClass, true));*/


	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Save()
	{
		PlayerInfo playerInfo = new PlayerInfo(player.speed, player.player.position,player.HP);
		string jsonToFile = JsonUtility.ToJson(playerInfo, true);
		//Debug.Log(jsonToFile);

		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");

		File.WriteAllText(fliePath, jsonToFile);
	}
	public void Load()
	{
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		PlayerInfo newMyClass = JsonUtility.FromJson<PlayerInfo>(jsonFormFile);

		player.speed = newMyClass.speed;
		player.position = newMyClass.position;
		player.HP = newMyClass.HP;
		if (player.player == null)
		{
			player.player = Instantiate(me, player.position, Quaternion.identity);
		}
		else
		{
			player.player.position = player.position;
		}



		//me.GetComponent<Player>();
	}
}
