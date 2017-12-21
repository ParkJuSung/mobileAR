using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {
    public GameObject bullet;

    public Transform firePos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
        {
			//Fire();

			RaycastHit hit;
			if(Physics.Raycast(firePos.position,firePos.forward,out hit,5))
			{
				
				if (hit.collider.tag == "Monster")
				{
					Debug.DrawRay(firePos.position, firePos.forward * 5, Color.blue, 5);
					//object[] _params = new object[2];
				}
			}
        }


	}
}
