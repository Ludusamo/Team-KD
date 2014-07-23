using UnityEngine;
using System.Collections;

public class PlayerController : Photon.MonoBehaviour {

	public float speed = 10f;
	
	void FixedUpdate() {
		if (photonView.isMine) {
			InputMovement();
		}
	}

	void InputMovement() {
		if (Input.GetKey (KeyCode.W))
			rigidbody2D.MovePosition (rigidbody2D.position + Vector2.up * Time.fixedDeltaTime * speed);
		
		if (Input.GetKey(KeyCode.S))
			rigidbody2D.MovePosition (rigidbody2D.position - Vector2.up * Time.fixedDeltaTime * speed);
		
		if (Input.GetKey(KeyCode.D))
			rigidbody2D.MovePosition (rigidbody2D.position + Vector2.right * Time.fixedDeltaTime * speed);
		
		if (Input.GetKey(KeyCode.A))
			rigidbody2D.MovePosition (rigidbody2D.position - Vector2.right * Time.fixedDeltaTime * speed);
	}

}
