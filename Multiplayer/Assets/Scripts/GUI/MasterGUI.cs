using UnityEngine;
using System.Collections;

public class MasterGUI : Photon.MonoBehaviour {

	public int stolengold;
	private ArrayList playerInfos;	// Arraylist of player info 

	// Use this for initialization
	void Start () {
		stolengold = 0;
		playerInfos = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Label (new Rect (Screen.width/2 + 100, Screen.height/2, 100, 100), "Gold Stolen: " + stolengold);
	}

	[RPC] public void setCenter(string name) {
		GameObject currentCenter = GameObject.FindGameObjectWithTag ("playedCard");
		if (currentCenter != null)
			PhotonNetwork.Destroy (currentCenter.GetComponent<PhotonView>());
		Destroy (currentCenter);
		GameObject centerCard = PhotonNetwork.Instantiate (name, Vector3.zero, Quaternion.identity, 0);
		InteractCard.deleteCloneInName (centerCard);
		centerCard.tag = "playedCard";
	}

	[RPC] public void stealGold (int amount) {
		stolengold += amount;
	}

	public ArrayList getPlayerInfos() {
		return playerInfos;
	}
}
