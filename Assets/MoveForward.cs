﻿using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	float speed = 10f;
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0, speed * Time.deltaTime, 0);

		pos += transform.rotation * velocity;

		transform.position = pos;
	
	}
}
