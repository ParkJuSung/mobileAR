using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridInfo{
	public GameObject cube;
	public bool[] wall = new bool[100];
	public int N = 10;
	public bool[] gridtpye = new bool[3];
	public GridInfo(GameObject cube,int N,bool[] wall)
	{


		for (int i =0;i<100;i++)
		{
			this.wall[i] = wall[i];
		}
	}

	public GridInfo()
	{

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
