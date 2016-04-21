using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	GameObject GUIScore;

	// Use this for initialization
	void Start () {

		GUIScore = GameObject.Find ("GameController");
		GUIScore.GetComponent<GameController> ().goalScore++;
	}


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.name == "Player") {
			Destroy(gameObject);
			GUIScore.GetComponent<GameController> ().actualScore++;
		}

	}

}
