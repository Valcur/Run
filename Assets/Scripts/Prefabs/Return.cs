using UnityEngine;
using System.Collections;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D coll) {
	
		if(coll.name == "Player")
			coll.transform.GetComponent<Player> ().moveSide = 1;
	}
}
