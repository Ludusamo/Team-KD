using UnityEngine;
using System.Collections;

public class InteractCard : MonoBehaviour {
	public GameObject omni;
	public int cardplace;

	// Use this for initialization
	void Start () {
		omni = GameObject.FindGameObjectWithTag ("Player");

	}

	void OnMouseDown () {
		//sets the card clicked in the center as if it was played
		transform.position = new Vector3 (0,0,0);
		//changes the card at the card position of the clicked card to a new random card
		omni.GetComponent<Player>().changeCard(cardplace);
	}

	// Update is called once per frame
	void Update () {
	}

	//Method sets the cardplace variable to the given parameter "place"
	void setCardPlace(int place) {
		cardplace = place; 	
	}
}
 