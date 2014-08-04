using UnityEngine;
using System.Collections;
using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class RoomGUI : Photon.MonoBehaviour {
	private bool shouldCreateLegend;	// boolean to whether the legend should appear
	private int legendPadding;	// Padding for the borders of the legend
	private int legendLabelHeight;
	private int legendLabelWidth;

	// This is used as a test for the legend
	public GameObject playerInfoPrefab;

	// Use this for initialization
	void Start () {
		shouldCreateLegend = false;
		legendLabelWidth = Screen.width / 3;
		legendLabelHeight = Screen.height / 12;
		legendPadding = 14;
	}
	
	// Update is called once per frame
	void Update () {

		// Creates the legend when the player presses tab
		if (Input.GetKeyDown (KeyCode.Tab)) {
			shouldCreateLegend = true;
		}

		if (Input.GetKeyUp (KeyCode.Tab)) {
			shouldCreateLegend = false;
		}
	}

	//Entire in-game GUI
	void OnGUI () {
		GUI.BeginGroup (new Rect(0,0,Screen.width,Screen.height));
		//GUI.skin = customskin;
		if (shouldCreateLegend) {
			createLegend();
		}
		GUI.EndGroup ();
	}

	// Creates the legend for all the player info
	void createLegend() {
		GUI.Box (new Rect (legendPadding, legendPadding, Screen.width - 2 * legendPadding, Screen.height - 2 * legendPadding), ""); 
		displayHeading ();
		GameObject masterGUI = GameObject.FindGameObjectWithTag ("MasterGUI");
		for(int i = 0; i < PhotonNetwork.playerList.Length; i++) {
			displayInfo(PhotonNetwork.playerList[i], i);
		}
	}

	void displayInfo(PhotonPlayer player,  int spacingValue) {
		PhotonHashTable info = player.customProperties;
		int newSpaceValue = spacingValue + 2;
		GUI.Label(new Rect(2 * legendPadding, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), (string) info["Name"]);
		GUI.Label(new Rect(2 * legendPadding + legendLabelWidth, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), "" + (int) info["Gold"]);
		GUI.Label(new Rect(2 * legendPadding + 2 * legendLabelWidth, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), "" + (int) info["Lives"]);

	}

	void displayHeading() {
		GUI.Label (new Rect (2 * legendPadding, legendPadding, legendLabelWidth, legendLabelHeight), "Name");
		GUI.Label (new Rect (2 * legendPadding + legendLabelWidth, legendPadding, legendLabelWidth, legendLabelHeight), "Gold\t");
		GUI.Label (new Rect (2 * legendPadding + legendLabelWidth * 2, legendPadding, legendLabelWidth, legendLabelHeight), "Lives");
	}
}
