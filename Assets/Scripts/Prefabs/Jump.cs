using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
		
		Rigidbody2D collRB;
		public float jumpForce = 1f;
		public float z;
		
		
		
		// Use this for initialization
		void Start () {
			jumpForce *= 1000;
		}
		
		// Update is called once per frame
		void Update () {
			
			
			
		}
		
		void OnCollisionEnter2D(Collision2D coll){
			
			collRB = coll.gameObject.GetComponent<Rigidbody2D> ();

			if (collRB.gameObject != null) {
				if(z > 0 && z < 90){
					collRB.AddForce(new Vector2(jumpForce * Mathf.Sin(z), jumpForce * Mathf.Cos(z)));
				}	
				else if(z > -90 && z < 0){
					collRB.AddForce(new Vector2(jumpForce * Mathf.Sin(z), jumpForce * Mathf.Cos(z)));
					Debug.Log("test");
				}
				else if(z > -180 && z < -90){
					collRB.AddForce(new Vector2(jumpForce * Mathf.Sin(z), jumpForce * Mathf.Cos(z)));
				}
				else if(z > -270 && z < -180){
					collRB.AddForce(new Vector2(jumpForce * Mathf.Sin(z), jumpForce * Mathf.Cos(z)));
				}
				//else
					//collRB.AddForce(new Vector2(0, jumpForce));
				
				
			}
			
		}

		void OnCollisionExit2D(Collision2D coll){
			collRB.transform.gameObject.GetComponent<Player>().canJump = false;
		}
			
	
			

}
