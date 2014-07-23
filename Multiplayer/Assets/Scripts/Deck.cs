using UnityEngine;
using System.Collections;

public class Deck : MonoBehaviour {

	protected ArrayList deck;
	
	// Use this for initialization
	public void Start () {
		deck = new ArrayList();
		RefreshDeck ();
	}
	
	// Update is called once per frame
	public void Update () {
		
	}
	
	//returns the top card of the deck and removes it from the deck.
	//if there is no cards in the deck, refresh it.
	public int getCard(){
		int nextCard = (int) deck[0];
		
		deck.RemoveAt (0);
		print (nextCard);
		if (deck.Count == 0) {
			RefreshDeck();
		}
		return nextCard;
	}
	
	//test that this deck work
	public void OnMouseDown(){
		getCard ();
	}
	
	// puts in 52 random cards into the deck
	public void RefreshDeck(){
		for (int i = 0; i <52; i++) {
			deck.Add(Random.Range(0, 13));
			//print (i);
			//deck.Add (i);
		}
	}
}

