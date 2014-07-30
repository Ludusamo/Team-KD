using UnityEngine;
using System.Collections;

public class PlayedPile : MonoBehaviour {
	// number
	private int currentNumber;
	// Use this for initialization
	void Start () {
		currentNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//add a card to pile obviously
	public void addNumber(int i){
		currentNumber += i;
	}
	
	public int returnNumber(){
		return currentNumber;
	}
	
	//blowup the pile
	public void resetPile(){
		currentNumber = 0;
	}
}