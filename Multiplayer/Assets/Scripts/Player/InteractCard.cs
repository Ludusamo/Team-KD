using UnityEngine;
using System.Collections;

public class InteractCard : MonoBehaviour {
	public GameObject omni, playedcard;
	public int cardplace, value;
	private bool played;

	// Use this for initialization
	void Start () {
		omni = GameObject.FindGameObjectWithTag ("Player");
		played = false;
	}

	void OnMouseDown () {
		if (played == false) {
			//sets the card clicked in the center as if it was played
			transform.position = new Vector3 (0, 0, 0);
			//changes the card at the card position of the clicked card to a new random card
			omni.GetComponent<Player> ().changeCard (cardplace);
			//adds more stolen gold
			omni.GetComponent<RoomGUI>().stealGold(value);
			//deletes the previous card played
			playedcard = GameObject.FindGameObjectWithTag ("playedCard");
			if (playedcard != null)
				Destroy (playedcard);
			//played cards have different properties from unplayed cards
			played = true;
			transform.gameObject.tag = "playedCard";
		}
	}

	// Update is called once per frame
	void Update () {
	}

	//Method sets the cardplace variable to the given parameter "place"
	void setCardPlace(int place) {
		cardplace = place; 	
	}
}
 