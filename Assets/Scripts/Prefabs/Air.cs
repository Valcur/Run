using UnityEngine;
using System.Collections;

public class Air : MonoBehaviour {

	Rigidbody2D collRB;
	public float airForce = 1f;



	// Use this for initialization
	void Start () {
		airForce *= 1000;
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerEnter2D(Collider2D coll){
	
		collRB = coll.gameObject.GetComponent<Rigidbody2D> ();
	
	}



	void OnTriggerStay2D(Collider2D coll){

		if (collRB.gameObject != null) {
			if(transform.rotation.z > 0 && transform.rotation.z < 90){
				collRB.AddForce(new Vector2(-airForce * Mathf.Sin(transform.rotation.z), airForce * Mathf.Cos(transform.rotation.z)));
			}	
			else if(transform.rotation.z > -90 && transform.rotation.z < 0){
				collRB.AddForce(new Vector2(airForce * Mathf.Sin(transform.rotation.z), airForce * Mathf.Cos(transform.rotation.z)));
				Debug.Log("test");
			}
			else if(transform.rotation.z > -180 && transform.rotation.z < -90){
				collRB.AddForce(new Vector2(airForce * Mathf.Sin(transform.rotation.z), -airForce * Mathf.Cos(transform.rotation.z)));
			}
			else if(transform.rotation.z > -270 && transform.rotation.z < -180){
				collRB.AddForce(new Vector2(-airForce * Mathf.Sin(transform.rotation.z), -airForce * Mathf.Cos(transform.rotation.z)));
			}


		
		}

	}
}
