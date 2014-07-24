using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour {
	public GameObject[] cardlist;
	public GameObject[] cards;
	public bool onTurn;

	// Use this for initialization
	void Start () {
		onTurn = true;
		//creates the player's hand at the beginning
		for (int i = 0; i < cards.Length; i++) {
			//creates a random card
			GameObject clonedCard;
			clonedCard = Instantiate (cardlist[Random.Range (0,11)]) as GameObject;
			//sets each of the three card slots in the player's hand as a random card
			cards[i] = clonedCard;
			//places the cards in their corresponding positions on the scene
			clonedCard.transform.position = new Vector3(-3 + i * 3, -3, 0);
			//cards set their position in the array in their own script in InteractCard
			clonedCard.SendMessage("setCardPlace", i);
		}
	}


	//Method changes the card in slot "cardslot" of the player's hand to a random card
	public void changeCard(int cardslot) {
		//creates a random card
		GameObject clonedCard;
		clonedCard = Instantiate (cardlist[Random.Range (0,11)]) as GameObject;
		//sets each of the three card slots in the player's hand as a random card
		cards[cardslot] = clonedCard;
		//places the cards in their corresponding positions on the scene
		clonedCard.transform.position = new Vector3(-3 + cardslot * 3, -3, 0);
		//cards set their position in the array in their own script in InteractCard
		clonedCard.SendMessage("setCardPlace", cardslot);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
