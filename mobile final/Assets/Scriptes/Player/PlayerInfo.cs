using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerInfo  {

	public  int speed;
	public Vector3 position;
	public int HP;
	public Transform player;
	public Light light;
	public PlayerInfo(int speed,Vector3 position, int HP)
	{
		this.speed = speed;
		this.position = position;
		this.HP = HP;
	}
	public PlayerInfo()
	{

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
