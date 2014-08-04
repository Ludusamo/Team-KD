using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	public int gold, lives;
	public string name;
	public PhotonPlayer player;

	// Use this for initialization
	void Start () {
		lives = 3;
		gold = 0;
		name = "TestName";
		player = PhotonNetwork.player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string newName) {
		name = newName;
	}
}
