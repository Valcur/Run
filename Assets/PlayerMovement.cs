using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int playerMaxSpeed = 200;
	public int playerMinSpeed = 5;
	public float playerAcceleration;


	public float playerSpeed = 15f;
	float rotSpeed = 750f;
	float speedChange = 0f;
	float z;

	// Use this for initialization
	void Start () {
	
	}

	
	// Update is called once per frame
	//Gere les mouvements du joueur de manière classique
	void Update () {



		//Quaternion rot = transform.rotation;
		//z = rot.eulerAngles.z;
		//z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

		Vector3 dir = Input.mousePosition - transform.position;
		dir.Normalize ();
		z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion desiredRot = Quaternion.Euler (0, 0, z);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		//transform.rotation = rot;





		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (1 * playerSpeed * Time.deltaTime * -1, 0, 0);
		//Vector3 velocity = new Vector3 (0, playerSpeed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;

		PlaneSpeed ();
		playerSpeed += playerAcceleration;


	}

	//retranscrit les mouvements du joueur de maniere realiste
	public void PlaneSpeed()
	{
		//Le joueur monte
		if (z > 180 && z < 360) {
			//Monte vers la gauche
			if(z > 270){
				speedChange = - (90 - (z - 270));
			}
			//Monte vers la droite
			else{
				speedChange = - (90 - (270 - z));
			}
		}
		//Le joueur descend
		else{
			//Descend vers la gauche
			if(z < 90){
				speedChange = z;
			}
			//Descend vers la droite
			else{
				speedChange = 180 - z;
			}
		}

		speedChange = speedChange / 1000;
		playerSpeed += speedChange;


		if (playerSpeed > playerMaxSpeed) {
			playerSpeed = playerMaxSpeed;
		} 
		else if (playerSpeed < playerMinSpeed) {
			playerSpeed = playerMinSpeed;
		}


	}
}
