using UnityEngine;
using System.Collections;

public class InteractCard : Photon.MonoBehaviour {
	public GameObject omni, GUIOmni, playedcard;
	public int cardplace, value;
	private bool played, moveit;

	// Use this for initialization
	void Start () {
		omni = GameObject.FindGameObjectWithTag ("Player");
		GUIOmni = GameObject.FindGameObjectWithTag ("GUI");
		played = false;
	}

	void OnMouseDown () {
		if (played == false) {
			played = true;
			//moves the card clicked to the center as if it was played
			moveit = true;
		}
	}
	void cardPlayed() {
		//changes the card at the card position of the clicked card to a new random card
		omni.GetComponent<Player> ().changeCard (cardplace);
		//adds more stolen gold
		GUIOmni.GetPhotonView().RPC ("stealGold", PhotonTargets.AllBufferedViaServer, value);
		GUIOmni.GetPhotonView().RPC ("setCenter", PhotonTargets.MasterClient, gameObject.name);
		//deletes the previous card played
		//playedcard = GameObject.FindGameObjectWithTag ("playedCard");
		//Destroy (playedcard);
		//transform.gameObject.tag = "playedCard";
		Destroy (gameObject);
	}

	void FixedUpdate() {
		float xTran = 0, yTran = 0;
		if (moveit == true) {
			xTran = Time.fixedDeltaTime * (0 - transform.position.x) * 10;
			yTran = Time.fixedDeltaTime * (0 - transform.position.y) * 10;
			transform.Translate (xTran, yTran, 0);
			if (Mathf.Abs(0 - transform.position.x) < 0.1 && Mathf.Abs(0 - transform.position.y) < 0.1) {
				transform.position = Vector3.zero;
				moveit = false;
				cardPlayed();
			}
		}
	}

	//Method sets the cardplace variable to the given parameter "place"
	void setCardPlace(int place) {
		cardplace = place; 	
	}

	public static void deleteCloneInName(GameObject obj) {
		obj.name = obj.name.Replace ("(Clone)", "");
	}
}
 