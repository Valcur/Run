using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public bool isEnemy = true;
	bool canShot = true;
	Vector2 pos, dir;



	void Start () {

		pos = transform.position;
		dir = transform.rotation * new Vector2(0,1);
	
	}


	void Update () {

		pos = transform.position;
		dir = transform.rotation * new Vector2(0, 1);

		RaycastHit2D hit = Physics2D.Raycast (pos, dir, 10f);
	
		if (hit.collider != null) 
		{
			if(canShot)
			{
				canShot = false;
				hit.collider.transform.GetComponent<LifeScript>().life--;
				Debug.Log("ok");
			}
		}
		Debug.DrawRay (new Vector3 (pos.x, pos.y, 0), new Vector3 (dir.x, dir.y, 0), Color.cyan);
	}
}
