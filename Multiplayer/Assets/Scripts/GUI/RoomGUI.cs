using UnityEngine;
using System.Collections;

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
		createTestPlayerInfo ();
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
		for(int i = 0; i < masterGUI.GetComponent<MasterGUI>().getPlayerInfos().Count; i++) {
			displayInfo((GameObject)masterGUI.GetComponent<MasterGUI>().getPlayerInfos()[i],i);
		}
	}

	void createTestPlayerInfo() {
		for (int i = 0; i < 10; i++) {
			GameObject clone = Instantiate (playerInfoPrefab) as GameObject;
			//newInfo (clone);
		}
	}

	void displayInfo(GameObject playerInfo,  int spacingValue) {
		PlayerInfo info = playerInfo.GetComponent<PlayerInfo> ();
		int newSpaceValue = spacingValue + 2;
		GUI.Label(new Rect(2*legendPadding, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), info.name);
		GUI.Label(new Rect(2*legendPadding + legendLabelWidth, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), "" + info.gold);
		GUI.Label(new Rect(2*legendPadding + 2*legendLabelWidth, legendPadding * newSpaceValue + legendPadding, legendLabelWidth, legendLabelHeight), "" + info.lives);

	}

	void displayHeading() {
		GUI.Label (new Rect (2 * legendPadding, legendPadding, legendLabelWidth, legendLabelHeight), "Name");
		GUI.Label (new Rect (2 * legendPadding + legendLabelWidth, legendPadding, legendLabelWidth, legendLabelHeight), "Gold\t");
		GUI.Label (new Rect (2 * legendPadding + legendLabelWidth * 2, legendPadding, legendLabelWidth, legendLabelHeight), "Lives");
	}
}
