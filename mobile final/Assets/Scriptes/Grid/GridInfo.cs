using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridInfo{
	public int[] wall = new int[100];
	public int N = 10;

	public bool[] gridtpye = new bool[3];
	public GridInfo(int N,int[] wall)
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
