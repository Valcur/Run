using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D coll) {

		if (coll.gameObject.name == "Player")
			coll.gameObject.GetComponent<Player> ().checkpointEnabled = true;
	
	}
}
