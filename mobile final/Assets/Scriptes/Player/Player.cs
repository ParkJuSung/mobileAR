using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour {

	// Use this for initialization
	public Animator anim;
	void Start () {
		anim = anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector3.left * JSONPlayer.instance.player.speed * Time.deltaTime);
			anim.SetBool("Iswalk", true);

		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * JSONPlayer.instance.player.speed * Time.deltaTime);
			anim.SetBool("Iswalk", true);
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * JSONPlayer.instance.player.speed * Time.deltaTime);
			anim.SetBool("Iswalk", true);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * JSONPlayer.instance.player.speed * Time.deltaTime);
			anim.SetBool("Iswalk", true);
		}

		if(Input.anyKey == false)
		{
			anim.SetBool("Iswalk", false);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.transform.tag == "Monster")
		{

		}
	}
}
