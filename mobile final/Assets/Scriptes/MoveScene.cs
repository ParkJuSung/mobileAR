using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class MoveScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gotoMain()
	{
		SceneManager.LoadScene("mobile");
		StartCoroutine(Load2());
		StartCoroutine(Load());
		
	}

	IEnumerator Load2()
	{
		yield return new WaitForSeconds(1.0f);
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		PlayerInfo newMyClass = JsonUtility.FromJson<PlayerInfo>(jsonFormFile);

		JSONPlayer.instance.player.position = newMyClass.position;
		JSONPlayer.instance.player.speed = newMyClass.speed;
		JSONPlayer.instance.player.HP = newMyClass.HP;
		//if (JSONPlayer.Instance.player.player == null)
		//{
		//Instantiate(Resources.Load("player", typeof(Transform)), JSONPlayer.instance.player.position, Quaternion.identity);
		JSONPlayer.instance.player.player = Instantiate(Resources.Load("player",typeof(Transform)), JSONPlayer.instance.player.position, Quaternion.identity) as Transform;
		//JSONPlayer.instance.player.light = Instantiate(Resources.Load("light", typeof(Light)), new Vector3(-82, 141, 143),Quaternion.Euler(50,-30,0)) as Light;
		//}
		//else
		//{
		JSONPlayer.instance.player.player.position = JSONPlayer.instance.player.position;
		//}
		StopCoroutine(Load2());
	}

	IEnumerator Load()
	{
		yield return new WaitForSeconds(3.0f);
		string fliePath = Path.Combine(Application.dataPath, "Resources/JsonMap.json");
		string jsonFormFile = File.ReadAllText(fliePath);

		GridInfo newMyClass = JsonUtility.FromJson<GridInfo>(jsonFormFile);
		for (int i = 0; i < 100; i++)
		{
			if (newMyClass.wall[i] == 0)
				continue;

			if (newMyClass.wall[i] == 1)
			{
				JSONGrid.Instance.cube[i] = Instantiate(Resources.Load("wall", typeof(GameObject)), Grid.GetVector(i), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.wall[i] = 1;
			}
			else if (newMyClass.wall[i] == 2)
			{
				JSONGrid.Instance.stone[i] = Instantiate(Resources.Load("Stone", typeof(GameObject)), Grid.GetVector(i), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.wall[i] = 2;
			}
			else if (newMyClass.wall[i] == 3)
			{
				JSONGrid.Instance.tree[i] = Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject)), Grid.GetVector(i), Quaternion.Euler(-90, 0, 0)) as GameObject;
				JSONGrid.Instance.grid.wall[i] = 3;
			}
		}
		StopCoroutine(Load());
	}
}
