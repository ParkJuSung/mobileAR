using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public float sansiblityX = 15.0f;
	public float sansiblityY = 15.0f;
	private void Start()
	{

	}
	private void LateUpdate()
	{
		transform.LookAt(target);
		if (Input.GetMouseButton(1))
		{
			transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * smoothSpeed*10);
			transform.RotateAround(target.position, Vector3.right, Input.GetAxis("Mouse Y") * smoothSpeed*10);
		}

		if(Input.GetAxis("Mouse ScrollWheel")<0)
		{
			if (Mathf.Abs(transform.position.z) < 10)
			{
				if(transform.position.z>0)
					transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
				else
					transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
			}
		}
		else if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{

			if (Mathf.Abs(transform.position.z) > 2)
			{
				if (transform.position.z < 0)
					transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
				else
					transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
			}
		}



	}
}
