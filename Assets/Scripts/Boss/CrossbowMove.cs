using UnityEngine;
using System.Collections;

public class CrossbowMove : MonoBehaviour {

	public float turnSpeed = 25f;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerStay2D(Collider2D coll){

		if (coll.gameObject.name == "Player") {
		
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + coll.GetComponent<Player>().moveSide * -10)), turnSpeed * Time.deltaTime);

			//transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z + coll.GetComponent<Player>().moveSide 10));
		
		
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay (transform.position, Vector3.up, Color.cyan);

		RaycastHit2D hit = Physics2D.Raycast (transform.position, -Vector3.up, Mathf.Infinity);

		if(hit != null)
			if(hit.collider.name == "Player")
				Debug.Log ("shoot");
	
	}
}
