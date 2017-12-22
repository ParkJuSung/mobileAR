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
			if (JSONGrid.Instance.grid.gridtpye[0])
			{
				JSONGrid.Instance.cube[temp] = Instantiate(Resources.Load("wall", typeof(GameObject))
					, GetVector(temp), Quaternion.identity) as GameObject;
				JSONGrid.Instance.grid.wall[temp] = 1;

			}
			else if (JSONGrid.Instance.grid.gridtpye[1])
			{
				if (JSONGrid.Instance.stone[temp] == null)
				{
					JSONGrid.Instance.stone[temp] =
					Instantiate(Resources.Load("Stone", typeof(GameObject))
							, GetVector(temp), Quaternion.identity) as GameObject;
				}
				if (JSONGrid.Instance.stone[temp + 1] == null)
				{
					JSONGrid.Instance.stone[temp + 1] =
					Instantiate(Resources.Load("Stone", typeof(GameObject))
							, GetVector(temp + 1), Quaternion.identity) as GameObject;
				}
				JSONGrid.Instance.grid.wall[temp] = 2;
				JSONGrid.Instance.grid.wall[temp+1] = 2;
			}
			else if (JSONGrid.Instance.grid.gridtpye[2])
			{
				if (JSONGrid.Instance.tree[temp] == null)
				{
					JSONGrid.Instance.tree[temp] =
						Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject))
								, GetVector(temp), Quaternion.Euler(-90,0, 0)) as GameObject;
				}

				if (JSONGrid.Instance.tree[temp + 1] == null)
				{
					JSONGrid.Instance.tree[temp + 1] =
					Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject))
							, GetVector(temp + 1), Quaternion.Euler(-90, 0, 0)) as GameObject;
				}
				if (JSONGrid.Instance.tree[temp + 10] == null)
				{
					JSONGrid.Instance.tree[temp + 10] =
					Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject))
							, GetVector(temp + 10), Quaternion.Euler(-90, 0, 0)) as GameObject;
				}
				if (JSONGrid.Instance.tree[temp + 11] == null)
				{
					JSONGrid.Instance.tree[temp + 11] =
					Instantiate(Resources.Load("Olive_Tree_Prefab", typeof(GameObject))
							, GetVector(temp + 11), Quaternion.Euler(-90, 0, 0)) as GameObject;
				}
				JSONGrid.Instance.grid.wall[temp] = 3;
				JSONGrid.Instance.grid.wall[temp + 1] = 3;
				JSONGrid.Instance.grid.wall[temp + 10] = 3;
				JSONGrid.Instance.grid.wall[temp + 11] = 3;

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
