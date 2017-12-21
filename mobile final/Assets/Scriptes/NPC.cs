using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NPC : MonoBehaviour {

	public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			player = GameObject.FindGameObjectWithTag("Player").transform;
			float distance = Vector3.Distance(player.position, transform.position);
			Debug.Log(distance);
			if(distance<=1)
			{
				SceneManager.LoadScene("Dialog");
			}
		}
	}
}
