using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstermanager : MonoBehaviour {

	public GameObject monster;
	public GameObject monster2;
	// Use this for initialization
	void Start () {
		StartCoroutine(MonsterSummon());
		StartCoroutine(Monster2Summon());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MonsterSummon()
	{
		while (true)
		{
			yield return new WaitForSeconds(5);
			Instantiate(monster, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
		}
	}

	IEnumerator Monster2Summon()
	{
		while (true)
		{
			yield return new WaitForSeconds(10);
			Instantiate(monster2, new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10)), Quaternion.identity);
		}
	}
}
