using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
	public int gold, lives;
	public string name;

	// Use this for initialization
	void Start () {
		gold = lives = 0;
		name = "TestName";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setName(string newName) {
		name = newName;
	}
}
