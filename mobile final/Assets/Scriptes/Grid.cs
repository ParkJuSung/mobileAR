using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	
	public GameObject player;
	private static int N = 10;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 11; i++)
		{
			Debug.DrawLine(new Vector3(i, 0, 0), new Vector3(i, 0, N), new Color(255, 0, 0), Mathf.Infinity);
			Debug.DrawLine(new Vector3(0, 0, i), new Vector3(N, 0, i), new Color(255, 0, 0), Mathf.Infinity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100))
		{
			int temp = GetGridNumber(hit.point);
			JSONGrid.Instance.grid.wall[temp] = true;
			if (JSONGrid.Instance.grid.gridtpye[0])
			{
					Instantiate(Resources.Load("wall", typeof(GameObject))
					, GetVector(temp), Quaternion.identity);
			}
			else if (JSONGrid.Instance.grid.gridtpye[1])
			{
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp + 1), Quaternion.identity) as GameObject;
			}
			else if (JSONGrid.Instance.grid.gridtpye[2])
			{
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp + 1), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp + 10), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.cube =
					Instantiate(Resources.Load("wall", typeof(GameObject)) 
							, GetVector(temp + 11), Quaternion.identity) as GameObject;
							
			}

		}
	}

	public static int GetGridNumber(Vector3 point)
	{
		Debug.Log((int)point.x + (int)point.z * N);
		return (int)point.x + (int)point.z * N;
	}

	public static Vector3 GetVector(int GridNumber)
	{
		return new Vector3(GridNumber % N + 0.5f, 0.5f, GridNumber / N + 0.5f);
	}

	


}
