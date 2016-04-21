using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float playerSpeed = 5f, jumpSpeed = 1f, flySpeed = 0.2f, bounceFallSpeed = 0.05f, returnDelay = 1, playerGravity = 1f;
	public float moveSide = 1;
	private bool isFlying = false, willBounce = false, shouldReturn = false;
	public bool canJump = true, isDead = false, checkpointEnabled = false;
	Rigidbody2D playerRB;

	public GameObject initialPos, checkpointPos;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Respawn si le joueur est mort
		if (isDead == true && checkpointEnabled == false) {
			transform.position = initialPos.transform.position;
			isDead = false;
		} else if (isDead == true && checkpointEnabled == true) {
			transform.position = checkpointPos.transform.position;
			isDead = false;
		}




		//Mouvement horizontal
		if(playerSpeed > 0)
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x + 1 * moveSide, transform.position.y, transform.position.z), playerSpeed * Time.deltaTime);

		//Si le joueur est dans le mauvais sens, se retorune petit à petit
		if(shouldReturn)
			if(moveSide < 1)
				moveSide += 0.01f;
			if(moveSide == 1)
				shouldReturn = false;
			

		//Saute si le joueur appuie sur la touche de saut et vole s'il garde appuyé
		if (Input.GetMouseButtonDown(0)) {
			if(canJump == false){
				playerRB.gravityScale = flySpeed;
				playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
				isFlying = true;
				//isJumping = false;
			}
			else if(canJump == true){
				playerRB.AddForce(new Vector2(0, 500 * jumpSpeed));
				playerRB.gravityScale = playerGravity;
				//isJumping = true;
				canJump = false;
				if(willBounce) {
					StartCoroutine(ReturnDelay());
					if(playerSpeed < 0)
						playerSpeed = - playerSpeed;
					willBounce = false;
				}
			}
		}
		if(Input.GetMouseButtonUp(0) && isFlying){
			playerRB.gravityScale = playerGravity;
			//isJumping = false;
			isFlying = false;
		}







		//Debut de la téléportation
		if (Input.GetMouseButtonDown(1)) {

			Vector2 pos = Input.mousePosition;
			pos = Camera.main.ScreenToWorldPoint(pos);
			transform.position = Vector2.Lerp(transform.position, new Vector2(pos.x, pos.y), 200 * Time.deltaTime);
		
		}




	}

	void OnCollisionExit2D(Collision2D coll){
		canJump = false;
		playerRB.gravityScale = playerGravity;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		//Collision avec un mur, changeant de sens le joueur au prochain saut
		if (coll.gameObject.name == "Bounce") {
			playerRB.velocity = new Vector2 (0, 0);
			playerRB.gravityScale = bounceFallSpeed;
			Debug.Log ("glue");
			playerSpeed = - playerSpeed;
			moveSide = - moveSide;
			canJump = true;
			//isJumping = false;
			willBounce = true;
			StopCoroutine(ReturnDelay());
		} else if(coll.gameObject.name == "Ceil"){

		} else {
			canJump = true;
			//isJumping = false;
			playerRB.gravityScale = playerGravity;

			if (playerSpeed < 0)
				playerSpeed = - playerSpeed;
		}
	}


	
	//Retourne le joueur apès un ceratin lapse de temps s'il est dans le mauvais sens
	IEnumerator ReturnDelay ()
	{
		yield return new WaitForSeconds (returnDelay);

	}


}
