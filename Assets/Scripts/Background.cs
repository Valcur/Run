using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float speed = 1f;
	public GameObject playerObj;
	float startPos;

	// Use this for initialization
	void Start () {

		startPos = transform.position.x;

	}

	// Update is called once per frame
	void Update () {
	
		Vector3 playerPos = new Vector3((playerObj.transform.position.x - startPos) / speed, transform.position.y, transform.position.z);
		transform.position = playerPos;

	}
}
