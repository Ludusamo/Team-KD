using UnityEngine;
using System.Collections;

public class InteractCard : MonoBehaviour {
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
			transform.position = new Vector3(transform.position.x,transform.position.y,-1);
			moveit = true;
		}
	}

	void cardPlayed() {
		//changes the card at the card position of the clicked card to a new random card
		omni.GetComponent<Player> ().changeCard (cardplace);
		//adds more stolen gold
		GUIOmni.GetComponent<RoomGUI>().stealGold(value);
		//deletes the previous card played
		playedcard = GameObject.FindGameObjectWithTag ("playedCard");
		if (playedcard != null)
			Destroy (playedcard);
		//played cards have different properties from unplayed cards
		transform.gameObject.tag = "playedCard";
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		float xTran = 0, yTran = 0;
		if (moveit == true) {
			xTran = Time.fixedDeltaTime * (0 - transform.position.x) * 10;
			yTran = Time.fixedDeltaTime * (0 - transform.position.y) * 10;
			transform.Translate (xTran, yTran, 0);
			if (Mathf.Abs(0 - transform.position.x) < 0.1 && Mathf.Abs(0 - transform.position.y) < 0.1) {
				transform.position = new Vector3(0,0,0);
				moveit = false;
				cardPlayed ();
			}
		}
	}

	//Method sets the cardplace variable to the given parameter "place"
	void setCardPlace(int place) {
		cardplace = place; 	
	}
}
 