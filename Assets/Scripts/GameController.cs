using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int goalScore, scoreText, actualScore;
	public GUIText GUIScore;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(goalScore > 0)
			scoreText = actualScore * (100 / goalScore);


	
			GUIScore.text = "" + scoreText.ToString ();

	
	}
}
