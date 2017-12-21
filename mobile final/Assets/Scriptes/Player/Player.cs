using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * JSONPlayer.Instance.player.speed * Time.deltaTime);

		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * JSONPlayer.Instance.player.speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * JSONPlayer.Instance.player.speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * JSONPlayer.Instance.player.speed * Time.deltaTime);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Monster")
		{

		}
	}
}
