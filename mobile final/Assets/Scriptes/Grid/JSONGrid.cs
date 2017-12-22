using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JSONGrid : MonoBehaviour {

	public static JSONGrid Instance = null;
	public GridInfo grid;
	public GameObject[] cube;
	public GameObject[] stone;
	public GameObject[] tree;

	/*public static JSONGrid Instance
	{
		get
		{
			if (instance == null)
				instance = new JSONGrid();

			return instance;
		}
	}*/
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

		cube = new GameObject[100];
		stone = new GameObject[100];
		tree = new GameObject[100];

		grid = new GridInfo();
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");
		string jsonFormFile = File.ReadAllText(fliePath);
		GridInfo newMyClass = JsonUtility.FromJson<GridInfo>(jsonFormFile);
		
		for (int i = 0; i < 100; i++)
		{
			grid.wall[i] = newMyClass.wall[i];
			//cube[i] = Resources.Load("wall", typeof(GameObject)) as GameObject;
		}
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void Save()
	{
		GridInfo gridInfo = new GridInfo(10,grid.wall);
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
			if (newMyClass.wall[i] == 0)
				continue;

			if (newMyClass.wall[i] == 1)
			{
				cube[i] = Instantiate(Resources.Load("wall", typeof(GameObject)), Grid.GetVector(i), Quaternion.identity) as GameObject;
				grid.wall[i] = 1;
			}
			else if (newMyClass.wall[i] == 2)
			{
				stone[i] = Instantiate(Resources.Load("Stone", typeof(GameObject)), Grid.GetVector(i), Quaternion.identity) as GameObject;
				grid.wall[i] = 2;
			}
			else if (newMyClass.wall[i] == 3)
			{
				tree[i] = Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject)), Grid.GetVector(i), Quaternion.Euler(-90, 0, 0)) as GameObject;
				grid.wall[i] = 3;
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
	//	GridInfo gridInfo = new GridInfo();
	//	string jsonToFile = JsonUtility.ToJson(gridInfo, true);
		//Debug.Log(jsonToFile);

	//	string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");

	//	File.WriteAllText(fliePath, jsonToFile);
		for (int i = 0; i < 100; i++)
		{
			switch(grid.wall[i])
			{
				case 1:
					Destroy(cube[i]);
					grid.wall[i] = 0;
					break;
				case 2:
					Destroy(stone[i]);
					grid.wall[i] = 0;
					break;
				case 3:
					Destroy(tree[i]);
					grid.wall[i] = 0;
					break;


			}
		}
		
	}




}
