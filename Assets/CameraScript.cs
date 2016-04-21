using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject playerObj;
	public bool shouldMove = true;

	void Start (){
		if (shouldMove) {
			Vector3 playerPos = new Vector3 (playerObj.transform.position.x, transform.position.y, transform.position.z);
			transform.position = playerPos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (shouldMove) {
			Vector3 playerPos = new Vector3 (playerObj.transform.position.x, transform.position.y, transform.position.z);
			transform.position = playerPos;
		}

	}
}
