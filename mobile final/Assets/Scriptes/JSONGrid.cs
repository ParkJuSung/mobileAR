using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JSONGrid : MonoBehaviour {

	public static JSONGrid Instance = null;
	public GridInfo grid;
	// Use this for initialization
	void Start()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}


		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		GridInfo newMyClass = JsonUtility.FromJson<GridInfo>(jsonFormFile);
		for (int i = 0; i < 100; i++)
		{
			grid.wall[i] = newMyClass.wall[i];
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void Save()
	{
		GridInfo gridInfo = new GridInfo(grid.cube,10,grid.wall);
		string jsonToFile = JsonUtility.ToJson(gridInfo, true);
		Debug.Log(jsonToFile);

		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");

		File.WriteAllText(fliePath, jsonToFile);
	}

	public void Load()
	{
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		GridInfo newMyClass = JsonUtility.FromJson<GridInfo>(jsonFormFile);
		for(int i =0;i<100;i++)
		{
			if (newMyClass.wall[i])
			{
				grid.cube= Instantiate(Resources.Load("wall", typeof(GameObject)) , Grid.GetVector(i), Quaternion.identity) as GameObject;
			}
			
		}
	}

	public void OneByOne()
	{
		grid.gridtpye[0] = true;
		grid.gridtpye[1] = false;
		grid.gridtpye[2] = false;
	}

	public void TwoByOne()
	{
		grid.gridtpye[0] = false;
		grid.gridtpye[1] = true;
		grid.gridtpye[2] = false;
	}

	public void TwoByTwo()
	{
		grid.gridtpye[0] = false;
		grid.gridtpye[1] = false;
		grid.gridtpye[2] = true;
	}

	public void Init()
	{
		GridInfo gridInfo = new GridInfo();
		string jsonToFile = JsonUtility.ToJson(gridInfo, true);
		//Debug.Log(jsonToFile);

		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");

		File.WriteAllText(fliePath, jsonToFile);
		for (int i = 0; i < 100; i++)
		{
			grid.wall[i] = false;
		}
		
	}




}
