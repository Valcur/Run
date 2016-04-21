using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour {

	public int life = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (life == 0)
			Destroy (gameObject);
	
	}
}
