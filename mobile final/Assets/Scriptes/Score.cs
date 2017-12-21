using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public Text t;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(JSONPlayer.instance.player.player!=null && JSONPlayer.instance.player.HP>0)
		{
			t.text = "Score" + Time.time;
		}
	}
}
