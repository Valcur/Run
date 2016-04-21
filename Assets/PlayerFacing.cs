using UnityEngine;
using System.Collections;

public class PlayerFacing : MonoBehaviour {

	private GameObject playerObj;
	private Transform player;

	float rotSpeed = 100f;

	void Start () {
	
		playerObj = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (playerObj != null)
		{
			player = playerObj.transform;
		}

		if (player == null) 
		{
			Debug.Log("Joueur non trouvé");
			return;
		}

		Vector3 dir = player.position - transform.position;
		dir.Normalize();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);


	

	
	}
}
