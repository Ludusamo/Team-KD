using UnityEngine;
using System.Collections;

public class RoomGUI : MonoBehaviour {
	public int stolengold;

	// Use this for initialization
	void Start () {
		stolengold = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Method reacts when more gold is stolen, adding to the stolengold count
	public void stealGold (int amount) {
		stolengold += amount;
	}

	//Entire in-game GUI
	void OnGUI () {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		//GUI.skin = customskin;
		GUI.Label (new Rect (Screen.width/2 + 100, Screen.height/2, 100, 100), "Gold Stolen: " + stolengold);
		GUI.EndGroup ();
	}
}
