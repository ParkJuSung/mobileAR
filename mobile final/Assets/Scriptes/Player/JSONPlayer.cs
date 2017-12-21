using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class JSONPlayer : MonoBehaviour {
	// Use this for initialization
	public static JSONPlayer instance = null;
	public Transform me;
	public PlayerInfo player;
	//public Transform me = null;

	/*public static JSONPlayer instance
	{
		get
		{
			if (Instance == null)
				Instance = new JSONPlayer();

			return Instance;
		}
	}*/
	void Start () {

			if(instance == null)
			{
				DontDestroyOnLoad(gameObject);
				instance = this;
			}
			else if(instance != this)
			{
				Destroy(gameObject);
			}
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		PlayerInfo tempP = JsonUtility.FromJson<PlayerInfo>(jsonFormFile);

		player.speed = tempP.speed;
		player.position = tempP.position;
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
	public  void Load()
	{
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		PlayerInfo newMyClass = JsonUtility.FromJson<PlayerInfo>(jsonFormFile);
		player = new PlayerInfo(newMyClass.speed, newMyClass.position,newMyClass.HP);
		//player.speed = newMyClass.speed;
		//player.position = newMyClass.position;
		//player.HP = newMyClass.HP;
		if (player.player == null)
		{
			player.player = Instantiate(Resources.Load("player",typeof(Transform)), player.position, Quaternion.identity) as Transform;
			//player.light = Instantiate(Resources.Load("light", typeof(Light)), new Vector3(-82, 141, 143), Quaternion.identity) as Light;
		}
		else
		{
			player.player.position = player.position;
		}



		//me.GetComponent<Player>();
	}
}
