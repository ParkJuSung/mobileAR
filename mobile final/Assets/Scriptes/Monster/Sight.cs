using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Sight : MonoBehaviour
{
    public GameObject Enemy;

	[SerializeField] private Transform ThisTr;
	[SerializeField] private Transform SearchPos;
	[SerializeField] private float value = 2;
	[SerializeField] private float Torque = 5.0f;
	[SerializeField] private bool flag = true;
	[SerializeField] private RaycastHit hit;



	void Start()
    {

		ThisTr = this.gameObject.GetComponent<Transform>();
        SearchPos = ThisTr;

    }

    void FixedUpdate()
    {
		AngleCalc();

		transform.Rotate(SearchPos.up, Torque * Time.deltaTime * 20);
		Debug.DrawRay(new Vector3(SearchPos.position.x,SearchPos.position.y+1.2f,SearchPos.position.z)
					  , SearchPos.forward*10, Color.green);

		if (Physics.Raycast(SearchPos.position, SearchPos.forward, out hit, 10.0f))
		{
			if (hit.collider.tag == "Player")
			{
				JSONPlayer.instance.player.HP--;
				if (JSONPlayer.instance.player.HP <= 0)
				{ 
				Destroy(JSONPlayer.instance.player.player.gameObject);
				PlayerInfo playerInfo = new PlayerInfo(JSONPlayer.instance.player.speed,
					JSONPlayer.instance.player.player.position, JSONPlayer.instance.player.HP);
				string jsonToFile = JsonUtility.ToJson(playerInfo, true);
				//Debug.Log(jsonToFile);

				string fliePath = Path.Combine(Application.dataPath, "Resources/JsonTest.json");

				File.WriteAllText(fliePath, jsonToFile);
				}

				Debug.Log(JSONPlayer.instance.player.HP);
			}
		}

	//	Debug.Log(transform.rotation.y);

	}

	void AngleCalc()
	{
		if (transform.rotation.y >= 0.45f)
		{
			value = 0;
			Torque = -5;
			flag = false;
		}
		else if (transform.rotation.y <= -0.45f)
		{
			value = 0;
			Torque = 5;
			flag = true;
		}
		if (flag == true) value += 1;
		else value -= 1;
	}
}